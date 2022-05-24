using App.ContaCorrente.Application.CQRS.Lancamentos.Queries;
using App.ContaCorrente.Domain.Entidades;
using App.ContaCorrente.Domain.Interfaces;
using App.ContaCorrente.Domain.Mensagem;
using App.ContaCorrente.Domain.Validacoes;
using MediatR;

namespace App.ContaCorrente.Application.CQRS.Lancamentos.Handlers
{
    public class GetLancamentoPeloIdQueryHandler : IRequestHandler<GetLancamentoPeloIdQuery, Lancamento>
    {
        private readonly ILancamentoRepositorio _lancamentoRepositorio;
        public GetLancamentoPeloIdQueryHandler(ILancamentoRepositorio lancamentoRepositorio)
        {
            _lancamentoRepositorio = lancamentoRepositorio;
        }
        public async Task<Lancamento> Handle(GetLancamentoPeloIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await _lancamentoRepositorio.GetPeloIdAsync(request.Id);
            }
            catch
            {
                throw new DomainException(Mensagens.ErroAoEfetuarConsulta);
            }
        }
    }
}
