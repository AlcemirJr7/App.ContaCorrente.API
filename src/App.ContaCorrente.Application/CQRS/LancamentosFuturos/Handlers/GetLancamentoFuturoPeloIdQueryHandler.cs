using App.ContaCorrente.Application.CQRS.LancamentosFuturos.Queries;
using App.ContaCorrente.Domain.Entidades;
using App.ContaCorrente.Domain.Interfaces;
using App.ContaCorrente.Domain.Mensagem;
using App.ContaCorrente.Domain.Validacoes;
using MediatR;

namespace App.ContaCorrente.Application.CQRS.LancamentosFuturos.Handlers
{
    public class GetLancamentoFuturoPeloIdQueryHandler : IRequestHandler<GetLancamentoFuturoPeloIdQuery, LancamentoFuturo>
    {
        private readonly ILancamentoFuturoRepositorio _lancamentoFuturoRepositorio;
        public GetLancamentoFuturoPeloIdQueryHandler(ILancamentoFuturoRepositorio lancamentoFuturoRepositorio)
        {
            _lancamentoFuturoRepositorio = lancamentoFuturoRepositorio;
        }

        public async Task<LancamentoFuturo> Handle(GetLancamentoFuturoPeloIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await _lancamentoFuturoRepositorio.GetPeloIdAsync(request.Id);
            }
            catch 
            {
                throw new DomainException(Mensagens.ErroAoEfetuarConsulta);
            }
        }
    }
}
