using App.ContaCorrente.Domain.Entidades;
using MediatR;

namespace App.ContaCorrente.Application.CQRS.Bancos.Queries
{
    public class GetBancosPeloIdQuery : IRequest<Banco>
    {
        public int Id { get; set; }
        public GetBancosPeloIdQuery(int id)
        {
            Id = id;
        }
    }
}
