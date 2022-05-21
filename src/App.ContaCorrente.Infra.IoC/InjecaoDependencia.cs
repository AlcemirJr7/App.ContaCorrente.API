using App.ContaCorrente.Application.Mapeamentos;
using App.ContaCorrente.Application.Servicos;
using App.ContaCorrente.Application.Servicos.Interfaces;
using App.ContaCorrente.Domain.Interfaces;
using App.ContaCorrente.Infra.Data.Contexto;
using App.ContaCorrente.Infra.Data.Repositorios;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


            // serviços
            services.AddScoped<IBancoServico, BancoServico>();
            services.AddScoped<IEnderecoServico, EnderecoServico>();



            var myHandlers = AppDomain.CurrentDomain.Load("App.ContaCorrente.Application");
            services.AddMediatR(myHandlers);

            services.AddAutoMapper(typeof(DomainToDTOMapeamentoProfile));
            services.AddAutoMapper(typeof(DTOToCommandMapeamentoProfile));

            

            return services;
        }
    }
}
