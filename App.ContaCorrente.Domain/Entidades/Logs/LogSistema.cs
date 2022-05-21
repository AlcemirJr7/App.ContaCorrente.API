using App.ContaCorrente.Domain.Validacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ContaCorrente.Domain.Entidades.Logs
{
    public class LogSistema
    {
        public int Id { get; protected set; }

        public DateTime DataLog { get; private set; }

        public string DescricaoLog { get; private set; }

        public LogSistema(DateTime dataLog, string descricaoLog)
        {
            ValidarEntidade(dataLog, descricaoLog);
        }

        public LogSistema(int id, DateTime dataLog, string descricaoLog)
        {
            DomainExcepitonValidacao.When(id < 0, "Id invalido.");
            ValidarEntidade(dataLog, descricaoLog);
        }
        
        private void ValidarEntidade(DateTime dataLog, string descricaoLog)
        {
            DomainExcepitonValidacao.When(string.IsNullOrEmpty(Convert.ToString(dataLog)), "Data log invalida.");
            DomainExcepitonValidacao.When(string.IsNullOrEmpty(descricaoLog), "Descrição do log invalida.");

            DescricaoLog = descricaoLog;
            DataLog = dataLog;

        }
    }
}
