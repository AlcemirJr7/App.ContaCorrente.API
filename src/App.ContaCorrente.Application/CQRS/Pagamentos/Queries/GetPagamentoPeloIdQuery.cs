using App.ContaCorrente.Domain.Entidades;
using MediatR;

namespace App.ContaCorrente.Application.CQRS.Pagamentos.Queries
{
    public class GetPagamentoPeloIdQuery : IRequest<Pagamento>
    {
        public int Id { get; set; }
        public GetPagamentoPeloIdQuery(int id)
        {
            Id = id;
        }
    }
}
