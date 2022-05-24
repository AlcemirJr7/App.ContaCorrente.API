using App.ContaCorrente.Application.CQRS.Pagamentos.Commands;
using App.ContaCorrente.Domain.Entidades;
using App.ContaCorrente.Domain.Interfaces;
using App.ContaCorrente.Domain.Mensagem;
using App.ContaCorrente.Domain.Validacoes;
using MediatR;

namespace App.ContaCorrente.Application.CQRS.Pagamentos.Handlers
{
    public class PagamentoCriarCommandHandler : IRequestHandler<PagamentoCriarCommand, Pagamento>
    {
        private readonly IPagamentoRepositorio _pagamentoRepositorio;
        public PagamentoCriarCommandHandler(IPagamentoRepositorio pagamentoRepositorio)
        {
            _pagamentoRepositorio = pagamentoRepositorio;
        }
        public async Task<Pagamento> Handle(PagamentoCriarCommand request, CancellationToken cancellationToken)
        {
            var pagamento = new Pagamento(request.CodigoBarra,request.NumeroDocumento,request.DataGeracao,request.Valor,request.DataVencimento,
                                          request.DataPagamento,request.CorrentistaId);

            if(pagamento == null)
            {
                throw new DomainException(String.Format(Mensagens.EntidadeNaoCarregada, nameof(Pagamento)));
            }
            else
            {
                return await _pagamentoRepositorio.CriarAsync(pagamento);
            }
        }
    }
}
