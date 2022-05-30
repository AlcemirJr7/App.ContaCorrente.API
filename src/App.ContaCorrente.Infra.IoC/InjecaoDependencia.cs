﻿using App.ContaCorrente.Application.Mapeamentos;
using App.ContaCorrente.Application.Servicos;
using App.ContaCorrente.Application.Servicos.Interfaces;
using App.ContaCorrente.Domain.Interfaces;
using App.ContaCorrente.Infra.Data.Contexto;
using App.ContaCorrente.Infra.Data.Repositorios;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace App.ContaCorrente.Infra.IoC
{
    public static class InjecaoDependencia
    {
        public static IServiceCollection AddInfraestrutura(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<AppDbContexto>(options =>           
            options.UseSqlServer(configuration.GetConnectionString("DataBase"
            ), b => b.MigrationsAssembly(typeof(AppDbContexto).Assembly.FullName)));

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
            services.AddScoped<IChavePixRepositorio, ChavePixRepositorio>();


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
            services.AddScoped<IChavePixServico, ChavePixServico>();


            var myHandlers = AppDomain.CurrentDomain.Load("App.ContaCorrente.Application");
            services.AddMediatR(myHandlers);

            services.AddAutoMapper(typeof(DomainToDTOMapeamentoProfile));
            services.AddAutoMapper(typeof(DTOToCommandMapeamentoProfile));
            
            return services;
        }
    }
}
