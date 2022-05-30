using App.ContaCorrente.Domain.Entidades;
using MediatR;

namespace App.ContaCorrente.Application.CQRS.ChavesPix.Queries
{
    public class GetChavePixPeloCorrentistaIdQuery : IRequest<ChavePix>
    {
        public int Id { get; set; }

        public GetChavePixPeloCorrentistaIdQuery(int id)
        {
            Id = id;
        }
    }
}
