using App.ContaCorrente.Job;
using App.ContaCorrente.Job.Jobs;
using Quartz;

var builder = WebApplication.CreateBuilder(args);


IHost host = Host.CreateDefaultBuilder()
    .ConfigureServices((hostContext, services) =>
    {
        services.AddInfraestruturaJob(builder.Configuration);
        
        services.AddQuartz(q =>
        {
            q.UseMicrosoftDependencyInjectionJobFactory();

            //Job Lançamentos Futuros
            var jobKeyLancamentosFuturos = new JobKey(Guid.NewGuid().ToString()  + "LancamentosFuturos");

            q.AddJob<ProcessaLancamentosFuturosJob>(o => o.WithIdentity(jobKeyLancamentosFuturos));

            q.AddTrigger(o =>
            {
                o.ForJob(jobKeyLancamentosFuturos)
                .WithIdentity(Guid.NewGuid().ToString() + "LancamentosFuturos")
                .WithCronSchedule("0 0/1 * * * ?"); // roda a cada 1 min
            });

            //Job Parcelas Emprestimo
            var jobKeyParcelasEmprestimo = new JobKey(Guid.NewGuid().ToString() + "ParcelasEmprestimo");

            q.AddJob<ProcessaParcelasEmprestimoJob>(o => o.WithIdentity(jobKeyParcelasEmprestimo));

            q.AddTrigger(o =>
            {
                o.ForJob(jobKeyParcelasEmprestimo)
                .WithIdentity(Guid.NewGuid().ToString() + "ParcelasEmprestimo")
                .WithCronSchedule("0 0/1 * * * ?"); // roda a cada 1 min
            });

            services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);

        });


    }).Build();

await host.RunAsync();




