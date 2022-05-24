using App.ContaCorrente.Application.CQRS.Pagamentos.Queries;
using App.ContaCorrente.Domain.Entidades;
using App.ContaCorrente.Domain.Interfaces;
using App.ContaCorrente.Domain.Mensagem;
using App.ContaCorrente.Domain.Validacoes;
using MediatR;

namespace App.ContaCorrente.Application.CQRS.Pagamentos.Handlers
{
    public class GetPagamentoPeloIdQueryHandler : IRequestHandler<GetPagamentoPeloIdQuery, Pagamento>
    {
        private readonly IPagamentoRepositorio _pagamentoRepositorio;
        public GetPagamentoPeloIdQueryHandler(IPagamentoRepositorio pagamentoRepositorio)
        {
            _pagamentoRepositorio = pagamentoRepositorio;
        }

        public async Task<Pagamento> Handle(GetPagamentoPeloIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await _pagamentoRepositorio.GetPeloIdAsync(request.Id);
            }
            catch
            {
                throw new DomainException(Mensagens.ErroAoEfetuarConsulta);
            }
        }
    }
}
