using App.ContaCorrente.Domain.Entidades;
using MediatR;

namespace App.ContaCorrente.Application.CQRS.LancamentosFuturos.Queries
{
    public class GetLancamentoFuturoPeloCorrentistaIdQuery : IRequest<IEnumerable<LancamentoFuturo>>
    {
        public int Id { get; set; }

        public GetLancamentoFuturoPeloCorrentistaIdQuery(int id)
        {
            Id = id;
        }
    }
}
