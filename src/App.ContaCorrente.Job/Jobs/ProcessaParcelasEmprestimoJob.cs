using App.ContaCorrente.Application.Servicos.Interfaces;
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
            _logger.LogInformation("{time} - Efetivando Parcelas Emprestimo... ", DateTimeOffset.Now.DateTime);
            await Processar();
            await Task.CompletedTask.WaitAsync(context.JobRunTime);
        }

        private async Task Processar()
        {
            _logger.LogInformation("{time} - Processo Parcelas Emprestimo...", DateTimeOffset.Now.DateTime);
        }
    }
}
