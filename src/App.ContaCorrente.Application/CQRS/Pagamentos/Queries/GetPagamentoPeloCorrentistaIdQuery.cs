using App.ContaCorrente.Domain.Entidades;
using MediatR;

namespace App.ContaCorrente.Application.CQRS.Pagamentos.Queries
{
    public class GetPagamentoPeloCorrentistaIdQuery : IRequest<IEnumerable<Pagamento>>
    {
        public int Id { get; set; }
        public GetPagamentoPeloCorrentistaIdQuery(int id)
        {
            Id = id;
        }
    }
}
