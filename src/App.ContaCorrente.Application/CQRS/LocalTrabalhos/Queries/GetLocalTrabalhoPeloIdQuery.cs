using App.ContaCorrente.Domain.Entidades;
using MediatR;

namespace App.ContaCorrente.Application.CQRS.LocalTrabalhos.Queries
{
    public class GetLocalTrabalhoPeloIdQuery : IRequest<LocalTrabalho>
    {
        public int Id { get; set; }
        public GetLocalTrabalhoPeloIdQuery(int id)
        {
            Id = id;
        }
    }
}
