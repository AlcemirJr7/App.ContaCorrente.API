using App.ContaCorrente.Domain.Entidades;

namespace App.ContaCorrente.Application.DTOs
{
    public class SaldoContaCorrenteDTO
    {
        public int Id { get; set; }

        public decimal SaldoConta { get; set; }

        public DateTime? DataUltimaTransacao { get; set; }

        public decimal? LimiteChequeEspecial { get; set; }

        public int CorrentistaId { get; set; }
        
    }
}
