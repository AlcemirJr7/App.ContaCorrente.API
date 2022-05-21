using App.ContaCorrente.Domain.Validacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ContaCorrente.Domain.Entidades.Logs
{
    public class LogContaCorrente
    {
        public int Id { get; protected set; }

        public DateTime DataLog { get; private set; }

        public string? DescricaoLog { get; private set; }

        public int CorrentistaId { get; set; }

        public Correntista Correntista { get; set; }

        public LogContaCorrente(DateTime dataLog, string? descricaoLog)
        {
            ValidarEntidade(dataLog, descricaoLog);
        }

        public LogContaCorrente(int id, DateTime dataLog, string? descricaoLog)
        {
            DomainExcepitonValidacao.When(id < 0, "Id invalido.");
            ValidarEntidade(dataLog, descricaoLog);
        }

        public LogContaCorrente(DateTime dataLog, string? descricaoLog, int correntistaId)
        {
            ValidarEntidade(dataLog, descricaoLog);
            CorrentistaId = correntistaId;
        }

        private void ValidarEntidade(DateTime dataLog, string? descricaoLog)
        {
            DomainExcepitonValidacao.When(string.IsNullOrEmpty(Convert.ToString(dataLog)), "Data log invalida.");
            
            DescricaoLog = descricaoLog;
            DataLog = dataLog;

        }

    }
}
