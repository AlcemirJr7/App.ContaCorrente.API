using App.ContaCorrente.Domain.Entidades;
using MediatR;

namespace App.ContaCorrente.Application.CQRS.ParcelasEmprestimos.Queries
{
    public class GetParcelasEmprestimoPeloEmprestimoIdQuery : IRequest<IEnumerable<ParcelasEmprestimo>>
    {
        public int Id { get; set; }
        public GetParcelasEmprestimoPeloEmprestimoIdQuery(int id)
        {
            Id = id;
        }
    }
}
