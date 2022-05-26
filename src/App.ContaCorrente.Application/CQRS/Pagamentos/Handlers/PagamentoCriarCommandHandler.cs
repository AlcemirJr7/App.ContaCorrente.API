using App.ContaCorrente.Application.CQRS.Pagamentos.Commands;
using App.ContaCorrente.Application.Servicos.Interfaces;
using App.ContaCorrente.Domain.Entidades;
using App.ContaCorrente.Domain.Enumerador;
using App.ContaCorrente.Domain.Interfaces;
using App.ContaCorrente.Domain.Mensagem;
using App.ContaCorrente.Domain.Validacoes;
using MediatR;

namespace App.ContaCorrente.Application.CQRS.Pagamentos.Handlers
{
    public class PagamentoCriarCommandHandler : IRequestHandler<PagamentoCriarCommand, Pagamento>
    {
        private readonly IPagamentoRepositorio _pagamentoRepositorio;
        private readonly ISaldoContaCorrenteServico _saldoContaCorrenteServico;
        private readonly ILancamentoServico _lancamentoServico;
        private readonly ILancamentoRepositorio _lancamentoRepositorio;
        public PagamentoCriarCommandHandler(IPagamentoRepositorio pagamentoRepositorio, ISaldoContaCorrenteServico saldoContaCorrenteServico,
                                            ILancamentoServico lancamentoServico, ILancamentoRepositorio lancamentoRepositorio)
        {
            _pagamentoRepositorio = pagamentoRepositorio;
            _saldoContaCorrenteServico = saldoContaCorrenteServico;
            _lancamentoServico = lancamentoServico;
            _lancamentoRepositorio = lancamentoRepositorio;
        }
        public async Task<Pagamento> Handle(PagamentoCriarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                //validar saldo 
                await _saldoContaCorrenteServico.ValidaSaldoAsync(request.CorrentistaId, (int)EnumPagamentoHistorico.historico, request.Valor);
                
                var lancamento = new Lancamento(DateTime.Now,request.Valor,request.CodigoBarra,request.CorrentistaId,(int)EnumPagamentoHistorico.historico);
                
                //Cria Lançamento
                await _lancamentoRepositorio.CriarAsync(lancamento);                

                //Atualiza o saldo
                await _saldoContaCorrenteServico.AtulizaSaldoAsync(request.CorrentistaId, (int)EnumPagamentoHistorico.historico, request.Valor);

                var pagamento = new Pagamento(request.CodigoBarra, request.NumeroDocumento, request.DataGeracao, request.Valor, request.DataVencimento,
                                              request.DataPagamento,request.DataAgendamento ,request.CorrentistaId);

                if (pagamento == null)
                {
                    throw new DomainException(String.Format(Mensagens.EntidadeNaoCarregada, nameof(Pagamento)));
                }
                
                //Cria o pagamento                
                return await _pagamentoRepositorio.CriarAsync(pagamento);
                

            }
            catch (DomainException e)
            {
                throw new DomainException(e.Message);

            }catch (DomainExcepitonValidacao e)
            {
                throw new DomainExcepitonValidacao(e.Message);
            }
            
        }
    }
}
