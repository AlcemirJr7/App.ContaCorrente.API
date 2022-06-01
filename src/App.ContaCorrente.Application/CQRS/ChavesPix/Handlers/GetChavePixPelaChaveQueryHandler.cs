using App.ContaCorrente.Application.CQRS.ChavesPix.Queries;
using App.ContaCorrente.Domain.Entidades;
using App.ContaCorrente.Domain.Interfaces;
using App.ContaCorrente.Domain.Validacoes;
using MediatR;

namespace App.ContaCorrente.Application.CQRS.ChavesPix.Handlers
{
    public class GetChavePixPelaChaveQueryHandler : IRequestHandler<GetChavePixPelaChaveQuery, ChavePix>
    {
        private readonly IChavePixRepositorio _chavePixRepositorio;
        public GetChavePixPelaChaveQueryHandler(IChavePixRepositorio chavePixRepositorio)
        {
            _chavePixRepositorio = chavePixRepositorio;
        }
        public async Task<ChavePix> Handle(GetChavePixPelaChaveQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await _chavePixRepositorio.GetChavePixAtivaPelaChaveAsync(request.Chave);
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
