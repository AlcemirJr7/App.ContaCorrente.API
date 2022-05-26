namespace App.ContaCorrente.Application.DTOs
{
    public class ParcelasEmprestimoDTO
    {
        public ParcelasEmprestimoDTO()
        {

        }

        public int Id { get; set; }

        public decimal Valor { get; set; }

        public int SeqParcelas { get; set; }

        public DateTime DataVencimento { get; set; }

        public DateTime? DataPagamento { get; set; }

        public int EmprestimoId { get; set; }
        
    }
}
