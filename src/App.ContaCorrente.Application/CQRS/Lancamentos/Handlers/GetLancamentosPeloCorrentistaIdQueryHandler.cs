using App.ContaCorrente.Application.CQRS.Lancamentos.Queries;
using App.ContaCorrente.Domain.Entidades;
using App.ContaCorrente.Domain.Interfaces;
using App.ContaCorrente.Domain.Mensagem;
using App.ContaCorrente.Domain.Validacoes;
using MediatR;

namespace App.ContaCorrente.Application.CQRS.Lancamentos.Handlers
{
    public class GetLancamentosPeloCorrentistaIdQueryHandler : IRequestHandler<GetLancamentosPeloCorrentistaIdQuery, IEnumerable<Lancamento>>
    {
        private readonly ILancamentoRepositorio _lancamentoRepositorio;
        public GetLancamentosPeloCorrentistaIdQueryHandler(ILancamentoRepositorio lancamentoRepositorio)
        {
            _lancamentoRepositorio = lancamentoRepositorio;
        }
        public async Task<IEnumerable<Lancamento>> Handle(GetLancamentosPeloCorrentistaIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await _lancamentoRepositorio.GetPeloCorrentistaIdAsync(request.Id);
            }
            catch 
            {
                throw new DomainException(Mensagens.ErroAoEfetuarConsulta);
            }
        }
    }
}
