using App.ContaCorrente.Application.DTOs;
using App.ContaCorrente.Application.Servicos.Interfaces;
using App.ContaCorrente.Domain.Validacoes;
using App.ContaCorrente.Infra.Data.Contexto;
using Quartz;


namespace App.ContaCorrente.Job
{
    [DisallowConcurrentExecution]
    public class ProcessaLancamentosFuturosJob : IJob
    {
        private IConfiguration _configuration;        
        private readonly ILancamentoFuturoServico _lancamentoFuturoServico;  
        private readonly ILogger<ProcessaLancamentosFuturosJob> _logger;
        private readonly AppDbContexto _appDbContexto;

        public ProcessaLancamentosFuturosJob(ILogger<ProcessaLancamentosFuturosJob> logger, IConfiguration configuration, 
                                             ILancamentoFuturoServico lancamentoFuturoServico, AppDbContexto appDbContexto)
        {
            _logger = logger;            
            _configuration = configuration;                                      
            _lancamentoFuturoServico = lancamentoFuturoServico;
            _appDbContexto = appDbContexto; 
        }
        
        public async Task Execute(IJobExecutionContext context)
        {            
            _logger.LogInformation("{time} - Efetivando Lancamentos Futuros... " , DateTimeOffset.Now.DateTime);
            await Processar();
            await Task.CompletedTask.WaitAsync(context.JobRunTime);
        }

        private async Task Processar()
        {
            using var tr = await _appDbContexto.Database.BeginTransactionAsync();

            IEnumerable<LancamentoFuturoDTO> lancamentos = new List<LancamentoFuturoDTO>();
            try
            {
                lancamentos = await _lancamentoFuturoServico.ProcessaLancamentosFuturos();
            }
            catch (DomainException e)
            {
                await tr.RollbackAsync();
                _logger.LogInformation("Erro ao processar job Lancamentos Futuros: " + e.Message);
            }
            catch (DomainExcepitonValidacao e)
            {
                await tr.RollbackAsync();
                _logger.LogInformation("Erro ao processar job Lancamentos Futuros: " + e.Message);
            }
            catch (Exception e)
            {
                await tr.RollbackAsync();
                _logger.LogInformation("Erro ao processar job Lancamentos Futuros: " + e.Message);
            }

            await tr.CommitAsync();

            foreach (var item in lancamentos)
            {                
                _logger.LogInformation("Lançamento Futuro Efetivado com sucesso ID:" + item.Id.ToString());
            }
                        
        }
               
    }
}
