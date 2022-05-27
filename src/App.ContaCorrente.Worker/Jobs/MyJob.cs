using App.ContaCorrente.Application.DTOs;
using App.ContaCorrente.Application.Servicos.Interfaces;
using App.ContaCorrente.Worker.Models;
using Microsoft.Data.SqlClient;
using Quartz;
using System.Data;

namespace App.ContaCorrente.Worker.Jobs
{
    [DisallowConcurrentExecution]
    public class MyJob : IJob
    {
        private IConfiguration _configuration;        
        private readonly ILogger<MyJob> _logger;        
        public MyJob(ILogger<MyJob> logger, IConfiguration configuration)
        {
            _logger = logger;            
            _configuration = configuration;                          
        }
        
        public Task Execute(IJobExecutionContext context)
        {
            _logger.LogInformation("{time} - Valor Lancamento Futuro: " + GeLancamentoFuturo(), DateTimeOffset.Now.DateTime);
            return Task.CompletedTask;
        }

        private decimal GeLancamentoFuturo()
        {
            SqlConnection con;
            SqlCommand cmd;
            //decimal _TotalRegistros = decimal.Zero;

            LancamentoFuturoDTO lancamentos = new LancamentoFuturoDTO();

            
            try
            {
                using (con = new SqlConnection(_configuration.GetConnectionString("DataBase")))
                {
                    cmd = new SqlCommand($"SELECT valor FROM LancamentosFuturos where flagLancamento = 1 and dataParaLancamento = '{DateTime.Now.ToString("yyyy-MM-dd")}'", con);
                    con.Open();

                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            lancamentos.Valor = (decimal)reader["valor"];                           
                        }
                    }

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return lancamentos.Valor;
        }        
    }
}
