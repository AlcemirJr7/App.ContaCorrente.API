using App.ContaCorrente.Domain.Entidades;
using MediatR;

namespace App.ContaCorrente.Application.CQRS.ParcelasEmprestimos.Commands
{
    public abstract class ParcelasEmprestimoCommand : IRequest<IEnumerable<ParcelasEmprestimo>>
    {
        
        public int Id { get; set; }

        public decimal Valor { get; set; }

        public int SeqParcelas { get; set; }

        public DateTime DataVencimento { get; set; }
        
        public DateTime? DataPagamento { get; set; }

        public int EmprestimoId { get; set; }
    }
}
