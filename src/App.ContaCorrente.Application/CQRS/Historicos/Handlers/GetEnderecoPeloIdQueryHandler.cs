using App.ContaCorrente.Application.CQRS.Historicos.Queries;
using App.ContaCorrente.Domain.Entidades;
using App.ContaCorrente.Domain.Interfaces;
using App.ContaCorrente.Domain.Mensagem;
using App.ContaCorrente.Domain.Validacoes;
using MediatR;


namespace App.ContaCorrente.Application.CQRS.Historicos.Handlers
{
    public class GetEnderecoPeloIdQueryHandler : IRequestHandler<GetHistoricoPeloIdQuery, Historico>
    {
        private readonly IHistoricoRepositorio _historicoRepositorio;
        public GetEnderecoPeloIdQueryHandler(IHistoricoRepositorio historicoRepositorio)
        {
            _historicoRepositorio = historicoRepositorio;
        }
        public async Task<Historico> Handle(GetHistoricoPeloIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await _historicoRepositorio.GetPeloIdAsync(request.Id);
            }
            catch 
            {
                throw new DomainException(Mensagens.ErroAoEfetuarConsulta);
            }
        }
    }
}
