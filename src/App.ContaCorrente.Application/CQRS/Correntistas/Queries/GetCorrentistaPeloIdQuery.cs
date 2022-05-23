
using App.ContaCorrente.Domain.Entidades;
using MediatR;

namespace App.ContaCorrente.Application.CQRS.Correntistas.Queries
{
    public class GetCorrentistaPeloIdQuery : IRequest<Correntista>
    {
        public int Id { get; set; }
        public GetCorrentistaPeloIdQuery(int id)
        {
            Id = id;
        }
    }
}
