using App.ContaCorrente.Application.CQRS.Pagamentos.Queries;
using App.ContaCorrente.Domain.Entidades;
using App.ContaCorrente.Domain.Interfaces;
using App.ContaCorrente.Domain.Mensagem;
using App.ContaCorrente.Domain.Validacoes;
using MediatR;

namespace App.ContaCorrente.Application.CQRS.Pagamentos.Handlers
{
    public class GetPagamentoPeloCorrentistaIdQueryHandler : IRequestHandler<GetPagamentoPeloCorrentistaIdQuery, IEnumerable<Pagamento>>
    {
        private readonly IPagamentoRepositorio _pagamentoRepositorio;
        public GetPagamentoPeloCorrentistaIdQueryHandler(IPagamentoRepositorio pagamentoRepositorio)
        {
            _pagamentoRepositorio = pagamentoRepositorio;
        }

        public async Task<IEnumerable<Pagamento>> Handle(GetPagamentoPeloCorrentistaIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await _pagamentoRepositorio.GetPeloCorrentistaIdAsync(request.Id);
            }
            catch 
            {
                throw new DomainException(Mensagens.ErroAoEfetuarConsulta);
            }
        }
    }
}
