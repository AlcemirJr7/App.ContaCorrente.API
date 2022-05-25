using App.ContaCorrente.Application.CQRS.Emprestimos.Queries;
using App.ContaCorrente.Domain.Entidades;
using App.ContaCorrente.Domain.Interfaces;
using App.ContaCorrente.Domain.Mensagem;
using App.ContaCorrente.Domain.Validacoes;
using MediatR;

namespace App.ContaCorrente.Application.CQRS.Emprestimos.Handlers
{
    public class GetEmprestimosPeloCorrentistaIdQueryHandler : IRequestHandler<GetEmprestimosPeloCorrentistaIdQuery, IEnumerable<Emprestimo>>
    {
        private readonly IEmprestimoRepositorio _emprestimoRepositorio;
        public GetEmprestimosPeloCorrentistaIdQueryHandler(IEmprestimoRepositorio emprestimoRepositorio)
        {
            _emprestimoRepositorio = emprestimoRepositorio;
        }

        public async Task<IEnumerable<Emprestimo>> Handle(GetEmprestimosPeloCorrentistaIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await _emprestimoRepositorio.GetPeloCorrentistaIdAsync(request.Id);
            }
            catch 
            {
                throw new DomainException(Mensagens.ErroAoEfetuarConsulta);
            }
        }
    }
}
