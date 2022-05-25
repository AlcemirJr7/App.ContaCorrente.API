using App.ContaCorrente.Domain.Entidades;
using MediatR;

namespace App.ContaCorrente.Application.CQRS.LancamentosFuturos.Queries
{
    public class GetLancamentoFuturoPeloIdQuery : IRequest<LancamentoFuturo>
    {
        public int Id { get; set; }

        public GetLancamentoFuturoPeloIdQuery(int id)
        {
            Id = id;
        }
    }
}
