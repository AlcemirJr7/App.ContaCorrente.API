using App.ContaCorrente.Domain.Entidades;
using MediatR;

namespace App.ContaCorrente.Application.CQRS.Lancamentos.Queries
{
    public class GetLancamentoPeloIdQuery : IRequest<Lancamento>
    {
        public int Id { get; set; }

        public GetLancamentoPeloIdQuery(int id)
        {
            Id = id;
        }
    }
}
