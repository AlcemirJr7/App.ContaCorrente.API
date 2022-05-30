using App.ContaCorrente.Application.CQRS.ChavesPix.Queries;
using App.ContaCorrente.Domain.Entidades;
using App.ContaCorrente.Domain.Interfaces;
using App.ContaCorrente.Domain.Validacoes;
using MediatR;

namespace App.ContaCorrente.Application.CQRS.ChavesPix.Handlers
{
    public class GetChavePixPeloCorrentistaIdQueryHandler : IRequestHandler<GetChavePixPeloCorrentistaIdQuery, ChavePix>
    {
        private readonly IChavePixRepositorio _chavePixRepositorio;
        public GetChavePixPeloCorrentistaIdQueryHandler(IChavePixRepositorio chavePixRepositorio)
        {
            _chavePixRepositorio = chavePixRepositorio;
        }

        public async Task<ChavePix> Handle(GetChavePixPeloCorrentistaIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await _chavePixRepositorio.GetChavePixPeloCorrentistaIdAsync(request.Id);
            }
            catch (DomainException e)
            {
                throw new DomainException(e.Message);
            }
            catch (DomainExcepitonValidacao e)
            {
                throw new DomainExcepitonValidacao(e.Message);
            }
        }
    }
}
