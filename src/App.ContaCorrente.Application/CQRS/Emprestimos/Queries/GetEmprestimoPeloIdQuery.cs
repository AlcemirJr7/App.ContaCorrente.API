using App.ContaCorrente.Domain.Entidades;
using MediatR;

namespace App.ContaCorrente.Application.CQRS.Emprestimos.Queries
{
    public class GetEmprestimoPeloIdQuery : IRequest<Emprestimo>
    {
        public int Id { get; set; }
        public GetEmprestimoPeloIdQuery(int id)
        {
            Id = id;
        }
    }
}
