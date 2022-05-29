using App.ContaCorrente.Application.CQRS.Pagamentos.Commands;
using App.ContaCorrente.Domain.Entidades;
using App.ContaCorrente.Domain.Enumerador;
using App.ContaCorrente.Domain.Interfaces;
using App.ContaCorrente.Domain.Mensagem;
using App.ContaCorrente.Domain.Utils;
using App.ContaCorrente.Domain.Validacoes;
using MediatR;

namespace App.ContaCorrente.Application.CQRS.Pagamentos.Handlers
{
    public class PagamentoCriarAgendamentoCommandHandler : IRequestHandler<PagamentoCriarAgendamentoCommand, Pagamento>
    {
        private readonly IPagamentoRepositorio _pagamentoRepositorio;
        private readonly ILancamentoFuturoRepositorio _lancamentoFuturoRepositorio; 
        public PagamentoCriarAgendamentoCommandHandler(IPagamentoRepositorio pagamentoRepositorio, ILancamentoFuturoRepositorio lancamentoFuturoRepositorio)
        {
            _pagamentoRepositorio = pagamentoRepositorio;
            _lancamentoFuturoRepositorio = lancamentoFuturoRepositorio; 
        }

        public async Task<Pagamento> Handle(PagamentoCriarAgendamentoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var pagamento = new Pagamento(request.CodigoBarra, request.NumeroDocumento, request.DataGeracao, request.Valor, request.DataVencimento,
                                              request.DataPagamento, request.DataAgendamento, request.CorrentistaId);
                                
                if (pagamento == null)
                {
                    throw new DomainException(String.Format(Mensagens.EntidadeNaoCarregada, nameof(Pagamento)));
                }

                var agendamento = await _pagamentoRepositorio.CriarAsync(pagamento);

                var lancamentoFuturo = new LancamentoFuturo(agendamento.Valor,DateTime.Now,agendamento.DataAgendamento.Value,EnumTipoLancamentoFuturo.Pagamento,
                                                            EnumLancamentoFuturo.Pendente,null,StringFormata.ApenasNumeros(agendamento.CodigoBarra),pagamento.Id,
                                                            EnumSituacaoLancamentoFuturo.Ativo,(int)EnumPagamentoHistorico.historico,agendamento.CorrentistaId);
                
                if (lancamentoFuturo == null)
                {
                    throw new DomainException(String.Format(Mensagens.EntidadeNaoCarregada, nameof(LancamentoFuturo)));
                }

                await _lancamentoFuturoRepositorio.CriarAsync(lancamentoFuturo);


                return agendamento; 

                
            }
            catch 
            {
                throw new DomainException(Mensagens.ErroAoAgendarPagamento);
            }
        }
    }
}
