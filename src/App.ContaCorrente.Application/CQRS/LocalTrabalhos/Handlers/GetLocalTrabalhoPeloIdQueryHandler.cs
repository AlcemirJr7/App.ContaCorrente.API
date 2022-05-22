using App.ContaCorrente.Application.CQRS.LocalTrabalhos.Queries;
using App.ContaCorrente.Domain.Entidades;
using App.ContaCorrente.Domain.Interfaces;
using App.ContaCorrente.Domain.Mensagem;
using App.ContaCorrente.Domain.Validacoes;
using MediatR;


namespace App.ContaCorrente.Application.CQRS.LocalTrabalhos.Handlers
{
    public class GetLocalTrabalhoPeloIdQueryHandler : IRequestHandler<GetLocalTrabalhoPeloIdQuery, LocalTrabalho>
    {
        private readonly ILocalTrabalhoRepositorio _localTrabalhoRepositorio;
        public GetLocalTrabalhoPeloIdQueryHandler(ILocalTrabalhoRepositorio localTrabalhoRepositorio)
        {
            _localTrabalhoRepositorio = localTrabalhoRepositorio;
        }

        public async Task<LocalTrabalho> Handle(GetLocalTrabalhoPeloIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await _localTrabalhoRepositorio.GetPeloIdAsync(request.Id);
            }
            catch 
            {
                throw new DomainException(Mensagens.ErroAoEfetuarConsulta);
            }
        }
    }
}
