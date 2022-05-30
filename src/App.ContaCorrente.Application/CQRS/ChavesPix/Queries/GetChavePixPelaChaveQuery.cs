using App.ContaCorrente.Domain.Entidades;
using MediatR;

namespace App.ContaCorrente.Application.CQRS.ChavesPix.Queries
{
    public class GetChavePixPelaChaveQuery : IRequest<ChavePix>
    {
        public string Chave { get; set; }

        public GetChavePixPelaChaveQuery(string chave)
        {
            Chave = chave;
        }
    }
}
