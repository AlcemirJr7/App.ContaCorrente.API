using App.ContaCorrente.Domain.Validacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ContaCorrente.Domain.Entidades
{
    public class Transferencia
    {
        public int Id { get; protected set; }
        
        public long? NumeroConta { get; private set; }

        public int? Agencia { get; private set; }
        
        public DateTime DataTransferencia { get; private set; }

        public decimal Valor { get; private set; }

        public int? BancoId { get; set; }

        public Banco? Banco { get; set; }

        public int? CorrentistaRecebeId { get; set; }

        public Correntista? CorrentistaRecebe { get; set; }

        public int? CorrentistaEnviaId { get; set; }

        public Correntista? CorrentistaEnvia { get; set; }

        public Transferencia(long? numeroConta, int? agencia, DateTime dataTransferencia, decimal valor)
        {
            ValidarEntidade(numeroConta, agencia, dataTransferencia, valor);
        }

        public Transferencia(int id,long? numeroConta, int? agencia, DateTime dataTransferencia, decimal valor)
        {
            DomainExcepitonValidacao.When(id < 0, "Id invalido.");
            ValidarEntidade(numeroConta, agencia, dataTransferencia, valor);
        }


        public Transferencia(long? numeroConta, int? agencia, DateTime dataTransferencia, decimal valor, int? bancoId, int? correntistaRecebeId, int? correntistaEnviaId)
        {
            ValidarEntidade(numeroConta, agencia, dataTransferencia, valor);
            BancoId = bancoId;
            CorrentistaRecebeId = correntistaRecebeId;
            CorrentistaEnviaId = correntistaEnviaId;    
        }
        
        private void ValidarEntidade(long? numeroConta, int? agencia, DateTime dataTransferencia, decimal valor)
        {
            DomainExcepitonValidacao.When(valor <= 0, "Valor de transferencia invalido.");
            DomainExcepitonValidacao.When(string.IsNullOrEmpty(Convert.ToString(dataTransferencia)), "Data de transferencia invalida.");

            NumeroConta = numeroConta;
            Agencia = agencia;
            DataTransferencia = dataTransferencia;  
            Valor = valor;

        }

    }
}
