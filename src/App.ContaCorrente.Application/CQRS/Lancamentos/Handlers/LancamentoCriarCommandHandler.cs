using App.ContaCorrente.Application.CQRS.Lancamentos.Commands;
using App.ContaCorrente.Domain.Entidades;
using App.ContaCorrente.Domain.Interfaces;
using App.ContaCorrente.Domain.Mensagem;
using App.ContaCorrente.Domain.Validacoes;
using MediatR;

namespace App.ContaCorrente.Application.CQRS.Lancamentos.Handlers
{
    public class LancamentoCriarCommandHandler : IRequestHandler<LancamentoCriarCommand, Lancamento>
    {
        private readonly ILancamentoRepositorio _lancamentoRepositorio;
        private readonly ICorrentistaRepositorio _correntistaRepositorio;
        private readonly IHistoricoRepositorio _historicoRepositorio;
        public LancamentoCriarCommandHandler(ILancamentoRepositorio lancamentoRepositorio, ICorrentistaRepositorio correntistaRepositorio,
                                             IHistoricoRepositorio historicoRepositorio)
        {
            _lancamentoRepositorio = lancamentoRepositorio;
            _correntistaRepositorio = correntistaRepositorio;   
            _historicoRepositorio = historicoRepositorio;
        }
        public async Task<Lancamento> Handle(LancamentoCriarCommand request, CancellationToken cancellationToken)
        {
            var correntista = await _correntistaRepositorio.GetPeloIdAsync(request.CorrentistaId);

            if(correntista == null)
            {
                throw new DomainException(String.Format(Mensagens.EntidadeNaoCarregada, nameof(Correntista)));
            }

            var historico = await _historicoRepositorio.GetPeloIdAsync(request.HistoricoId);

            if (historico == null)
            {
                throw new DomainException(String.Format(Mensagens.EntidadeNaoCarregada, nameof(Historico)));
            }

            var lancamento = new Lancamento(DateTime.Now,request.Valor,request.Observacao,request.CorrentistaId,request.HistoricoId);
                     
            if(lancamento == null)
            {
                throw new DomainException(String.Format(Mensagens.EntidadeNaoCarregada, nameof(Lancamento)));
            }
            else
            {
                return await _lancamentoRepositorio.CriarAsync(lancamento);
            }
        }
    }
}
