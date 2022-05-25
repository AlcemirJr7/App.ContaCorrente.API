using App.ContaCorrente.Domain.Entidades;
using MediatR;

namespace App.ContaCorrente.Application.CQRS.Emprestimos.Queries
{
    public class GetEmprestimosPeloCorrentistaIdQuery : IRequest<IEnumerable<Emprestimo>>
    {
        public int Id { get; set; }
        public GetEmprestimosPeloCorrentistaIdQuery(int id)
        {
            Id = id;
        }
    }
}
