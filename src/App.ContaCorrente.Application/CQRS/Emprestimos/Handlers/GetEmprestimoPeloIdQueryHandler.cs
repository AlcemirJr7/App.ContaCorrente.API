using App.ContaCorrente.Application.CQRS.Emprestimos.Queries;
using App.ContaCorrente.Domain.Entidades;
using App.ContaCorrente.Domain.Interfaces;
using App.ContaCorrente.Domain.Mensagem;
using App.ContaCorrente.Domain.Validacoes;
using MediatR;

namespace App.ContaCorrente.Application.CQRS.Emprestimos.Handlers
{
    public class GetEmprestimoPeloIdQueryHandler : IRequestHandler<GetEmprestimoPeloIdQuery, Emprestimo>
    {
        private readonly IEmprestimoRepositorio _emprestimoRepositorio;
        public GetEmprestimoPeloIdQueryHandler(IEmprestimoRepositorio emprestimoRepositorio)
        {
            _emprestimoRepositorio = emprestimoRepositorio;
        }
        public async Task<Emprestimo> Handle(GetEmprestimoPeloIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await _emprestimoRepositorio.GetPeloIdAsync(request.Id);
            }
            catch 
            {
                throw new DomainException(Mensagens.ErroAoEfetuarConsulta);
            }
        }
    }
}
