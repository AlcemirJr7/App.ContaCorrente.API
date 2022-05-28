using App.ContaCorrente.Application.Servicos.Interfaces;
using Quartz;


namespace App.ContaCorrente.Job
{
    [DisallowConcurrentExecution]
    public class MyJob : IJob
    {
        private IConfiguration _configuration;        
        private readonly ILancamentoFuturoServico _lancamentoFuturoServico;  
        private readonly ILogger<MyJob> _logger;      

        public MyJob(ILogger<MyJob> logger, IConfiguration configuration, ILancamentoFuturoServico lancamentoFuturoServico)
        {
            _logger = logger;            
            _configuration = configuration;                                      
            _lancamentoFuturoServico = lancamentoFuturoServico;
        }
        
        public async Task Execute(IJobExecutionContext context)
        {            
            _logger.LogInformation("{time} - Efetivando Lancamentos Futuros... " , DateTimeOffset.Now.DateTime);
            await Processar();
            await Task.CompletedTask.WaitAsync(context.JobRunTime);
        }

        private async Task Processar()
        {
            var lancamentos = await _lancamentoFuturoServico.ProcessaLancamentosFuturos();

            foreach (var item in lancamentos)
            {                
                _logger.LogInformation("Lançamento Futuro Efetivado com sucesso ID:" + item.Id.ToString());
            }
                        
        }
               
    }
}
