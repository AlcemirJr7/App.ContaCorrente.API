using App.ContaCorrente.Domain.Entidades;
using MediatR;

namespace App.ContaCorrente.Application.CQRS.Lancamentos.Queries
{
    public class GetLancamentosPeloCorrentistaIdQuery : IRequest<IEnumerable<Lancamento>>
    {
        public int Id { get; set; }

        public GetLancamentosPeloCorrentistaIdQuery(int id)
        {
            Id = id;
        }
    }
}
