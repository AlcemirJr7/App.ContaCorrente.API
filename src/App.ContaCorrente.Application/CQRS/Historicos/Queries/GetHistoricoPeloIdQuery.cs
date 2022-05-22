using App.ContaCorrente.Domain.Entidades;
using MediatR;

namespace App.ContaCorrente.Application.CQRS.Historicos.Queries
{
    public class GetHistoricoPeloIdQuery : IRequest<Historico>
    {
        public int Id { get; set; }
        public GetHistoricoPeloIdQuery(int id)
        {
            Id = id;
        }
    }
}
