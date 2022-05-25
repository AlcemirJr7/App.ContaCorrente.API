using App.ContaCorrente.Application.CQRS.LancamentosFuturos.Commands;
using App.ContaCorrente.Domain.Entidades;
using App.ContaCorrente.Domain.Enumerador;
using App.ContaCorrente.Domain.Interfaces;
using App.ContaCorrente.Domain.Mensagem;
using App.ContaCorrente.Domain.Validacoes;
using MediatR;

namespace App.ContaCorrente.Application.CQRS.LancamentosFuturos.Handlers
{
    public class LancamentoFuturoCriarCommandHandler : IRequestHandler<LancamentoFuturoCriarCommand, LancamentoFuturo>
    {
        private readonly ILancamentoFuturoRepositorio _lancamentoFuturoRepositorio;
        private readonly ICorrentistaRepositorio _correntistaRepositorio;
        private readonly IHistoricoRepositorio _historicoRepositorio;
        public LancamentoFuturoCriarCommandHandler(ILancamentoFuturoRepositorio lancamentoFuturoRepositorio, ICorrentistaRepositorio correntistaRepositorio,
                                                   IHistoricoRepositorio historicoRepositorio)
        {
            _lancamentoFuturoRepositorio = lancamentoFuturoRepositorio;
            _correntistaRepositorio = correntistaRepositorio;
            _historicoRepositorio = historicoRepositorio;
        }
        public async Task<LancamentoFuturo> Handle(LancamentoFuturoCriarCommand request, CancellationToken cancellationToken)
        {
            var correntista = await _correntistaRepositorio.GetPeloIdAsync(request.CorrentistaId);

            if (correntista == null)
            {
                throw new DomainException(Mensagens.CorrentistaInvalido);
            }

            var historico = await _historicoRepositorio.GetPeloIdAsync(request.HistoricoId);

            if (historico == null)
            {
                throw new DomainException(Mensagens.HistoricoInvalido);
            }

            var lancamentoFuturo = new LancamentoFuturo(request.Valor,DateTime.Now,request.DataParaLancamento, EnumLancamentoFuturo.Pendente,
                                                        request.DataLancamento,request.HistoricoId,request.CorrentistaId);

            if(lancamentoFuturo == null)
            {
                throw new DomainException(String.Format(Mensagens.EntidadeNaoCarregada, nameof(Lancamento)));
            }
            else
            {
                return await _lancamentoFuturoRepositorio.CriarAsync(lancamentoFuturo);
            }
            
        }
    }
}
