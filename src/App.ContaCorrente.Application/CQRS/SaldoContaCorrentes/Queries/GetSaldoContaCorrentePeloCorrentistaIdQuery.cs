using App.ContaCorrente.Domain.Entidades;
using MediatR;

namespace App.ContaCorrente.Application.CQRS.SaldoContaCorrentes.Queries
{
    public class GetSaldoContaCorrentePeloCorrentistaIdQuery : IRequest<SaldoContaCorrente>
    {
        public int Id { get; set; }
        public GetSaldoContaCorrentePeloCorrentistaIdQuery(int id)
        {
            Id = id;
        }
    }
}
