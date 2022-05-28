using App.ContaCorrente.Application.DTOs;
using App.ContaCorrente.Application.Servicos.Interfaces;
using App.ContaCorrente.Domain.Validacoes;
using App.ContaCorrente.Infra.Data.Contexto;
using Quartz;

namespace App.ContaCorrente.Job.Jobs
{
    public class ProcessaParcelasEmprestimoJob : IJob
    {
        private IConfiguration _configuration;        
        private readonly ILogger<ProcessaParcelasEmprestimoJob> _logger;
        private readonly IParcelasEmprestimoServico _parcelasEmprestimoServico;
        private readonly AppDbContexto _appDbContexto;

        public ProcessaParcelasEmprestimoJob(ILogger<ProcessaParcelasEmprestimoJob> logger, IConfiguration configuration,
                                             AppDbContexto appDbContexto, IParcelasEmprestimoServico parcelasEmprestimoServico)
        {
            _logger = logger;
            _configuration = configuration;            
            _appDbContexto = appDbContexto;
            _parcelasEmprestimoServico = parcelasEmprestimoServico;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            _logger.LogInformation("{time} - Debitando Parcelas Emprestimo... ", DateTimeOffset.Now.DateTime);
            await Processar();
            await Task.CompletedTask.WaitAsync(context.JobRunTime);
        }

        private async Task Processar()
        {
            using var tr = await _appDbContexto.Database.BeginTransactionAsync();

            IEnumerable<ParcelasEmprestimoDTO> parcelasEmprestimos = new List<ParcelasEmprestimoDTO>();

            try
            {
                parcelasEmprestimos = await _parcelasEmprestimoServico.ProcessaPagamentoParcelaEmprestimo();
                
            }
            catch (DomainException e)
            {
                await tr.RollbackAsync();
                _logger.LogInformation("Erro ao processar job Parcelas Emprestimo: " + e.Message);
            }
            catch (DomainExcepitonValidacao e)
            {
                await tr.RollbackAsync();
                _logger.LogInformation("Erro ao processar job Parcelas Emprestimo: " + e.Message);
            }
            catch (Exception e)
            {
                await tr.RollbackAsync();
                _logger.LogInformation("Erro ao processar job Parcelas Emprestimo: " + e.Message);
            }

            await tr.CommitAsync();

            foreach (var parcela in parcelasEmprestimos)
            {
                _logger.LogInformation("Parcela emprestimo paga com sucesso SeqParcela:" + parcela.SeqParcelas.ToString() + " Emprestimo ID:" + parcela.EmprestimoId.ToString());
            }
            
        }
    }
}
