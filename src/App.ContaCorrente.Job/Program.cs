using App.ContaCorrente.Application.Mapeamentos;
using App.ContaCorrente.Application.Servicos;
using App.ContaCorrente.Application.Servicos.Interfaces;
using App.ContaCorrente.Domain.Interfaces;
using App.ContaCorrente.Infra.Data.Contexto;
using App.ContaCorrente.Infra.Data.Repositorios;
using App.ContaCorrente.Infra.IoC;
using App.ContaCorrente.Job;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Quartz;


IHost host = Host.CreateDefaultBuilder()
    .ConfigureServices((hostContext, services) =>
    {
        services.AddDbContext<AppDbContexto>(options =>
           options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DBContaCorrente; Integrated Security=True", b => b.MigrationsAssembly(typeof(AppDbContexto).Assembly.FullName)));

        //repositorios
        services.AddScoped<IBancoRepositorio, BancoRepositorio>();
        services.AddScoped<IEnderecoRepositorio, EnderecoRepositorio>();
        services.AddScoped<IHistoricoRepositorio, HistoricoRepositorio>();
        services.AddScoped<ILocalTrabalhoRepositorio, LocalTrabalhoRepositorio>();
        services.AddScoped<IPessoaRepositorio, PessoaRepositorio>();
        services.AddScoped<ICorrentistaRepositorio, CorrentistaRepositorio>();
        services.AddScoped<ISaldoContaCorrenteRepositorio, SaldoContaCorrenteRepositorio>();
        services.AddScoped<ILancamentoRepositorio, LancamentoRepositorio>();
        services.AddScoped<IPagamentoRepositorio, PagamentoRepositorio>();
        services.AddScoped<ILancamentoFuturoRepositorio, LancamentoFuturoRepositorio>();
        services.AddScoped<IEmprestimoRepositorio, EmprestimoRepositorio>();
        services.AddScoped<IParcelasEmprestimoRepositorio, ParcelasEmprestimoRepositorio>();


        // serviços
        services.AddScoped<IBancoServico, BancoServico>();
        services.AddScoped<IEnderecoServico, EnderecoServico>();
        services.AddScoped<IHistoricoServico, HistoricoServico>();
        services.AddScoped<ILocalTrabalhoServico, LocalTrabalhoServico>();
        services.AddScoped<IPessoaServico, PessoaServico>();
        services.AddScoped<ICorrentistaServico, CorrentistaServico>();
        services.AddScoped<ISaldoContaCorrenteServico, SaldoContaCorrenteServico>();
        services.AddScoped<ILancamentoServico, LancamentoServico>();
        services.AddScoped<IPagamentoServico, PagamentoServico>();
        services.AddScoped<ILancamentoFuturoServico, LancamentoFuturoServico>();
        services.AddScoped<IEmprestimoServico, EmprestimoServico>();
        services.AddScoped<IParcelasEmprestimoServico, ParcelasEmprestimoServico>();

        var myHandlers = AppDomain.CurrentDomain.Load("App.ContaCorrente.Application");
        services.AddMediatR(myHandlers);

        services.AddAutoMapper(typeof(DomainToDTOMapeamentoProfile));
        services.AddAutoMapper(typeof(DTOToCommandMapeamentoProfile));

        services.AddQuartz(q =>
        {
            q.UseMicrosoftDependencyInjectionScopedJobFactory();

            var jobKey = new JobKey(Guid.NewGuid().ToString());

            q.AddJob<MyJob>(o => o.WithIdentity(jobKey));

            q.AddTrigger(o =>
            {
                o.ForJob(jobKey)
                .WithIdentity(Guid.NewGuid().ToString())
                .WithCronSchedule("0 0/1 * * * ?");
            });

            services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);

        });


    }).Build();

await host.RunAsync();




