using App.ContaCorrente.Domain.Validacoes;

namespace App.ContaCorrente.Domain.Entidades
{
    public class SaldoContaCorrente
    {
        public int Id { get; protected set; }

        public decimal SaldoConta { get; private set; }

        public DateTime? DataUltimaTransacao { get; private set; }

        public decimal? LimiteChequeEspecial { get; private set; }

        public int CorrentistaId { get; set; }

        public Correntista Correntista { get; set; }

        public SaldoContaCorrente(decimal saldoConta, DateTime? dataUltimaTransacao, decimal? limiteChequeEspecial)
        {
            ValidarEntidade(saldoConta, dataUltimaTransacao, limiteChequeEspecial);
        }

        public SaldoContaCorrente(int id,decimal saldoConta, DateTime? dataUltimaTransacao, decimal? limiteChequeEspecial)
        {
            DomainExcepitonValidacao.When(id < 0,"Id invalido.");
            Id = id;
            ValidarEntidade(saldoConta, dataUltimaTransacao, limiteChequeEspecial);
        }

        public SaldoContaCorrente(int id, decimal saldoConta, DateTime? dataUltimaTransacao, decimal? limiteChequeEspecial, int correntistaId )
        {
            DomainExcepitonValidacao.When(id < 0, "Id invalido.");
            Id = id;
            CorrentistaId = correntistaId;
            ValidarEntidade(saldoConta, dataUltimaTransacao, limiteChequeEspecial);
        }

        public SaldoContaCorrente(decimal saldoConta, DateTime? dataUltimaTransacao, decimal? limiteChequeEspecial, int correntistaId)
        {
            ValidarEntidade(saldoConta, dataUltimaTransacao, limiteChequeEspecial);
            CorrentistaId = correntistaId;
        }

        public void Atualizar(decimal saldoConta, DateTime? dataUltimaTransacao, decimal? limiteChequeEspecial, int correntistaId)
        {
            ValidarEntidade(saldoConta, dataUltimaTransacao, limiteChequeEspecial);
            CorrentistaId = correntistaId;
        }

        private void ValidarEntidade(decimal saldoConta, DateTime? dataUltimaTransacao, decimal? limiteChequeEspecial)
        {
            DomainExcepitonValidacao.When(string.IsNullOrEmpty(Convert.ToString(saldoConta)), "Saldo não pode ser nulo.");
            SaldoConta = saldoConta;
            DataUltimaTransacao = dataUltimaTransacao;
            LimiteChequeEspecial = limiteChequeEspecial;

        }
    }
}
