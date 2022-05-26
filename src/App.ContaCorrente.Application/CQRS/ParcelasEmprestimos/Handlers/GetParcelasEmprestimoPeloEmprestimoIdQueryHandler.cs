using App.ContaCorrente.Application.CQRS.ParcelasEmprestimos.Queries;
using App.ContaCorrente.Domain.Entidades;
using App.ContaCorrente.Domain.Interfaces;
using MediatR;

namespace App.ContaCorrente.Application.CQRS.ParcelasEmprestimos.Handlers
{
    public class GetParcelasEmprestimoPeloEmprestimoIdQueryHandler : IRequestHandler<GetParcelasEmprestimoPeloEmprestimoIdQuery, IEnumerable<ParcelasEmprestimo>>
    {
        private readonly IParcelasEmprestimoRepositorio _parcelasEmprestimoRepositorio;
        public GetParcelasEmprestimoPeloEmprestimoIdQueryHandler(IParcelasEmprestimoRepositorio parcelasEmprestimoRepositorio)
        {
            _parcelasEmprestimoRepositorio = parcelasEmprestimoRepositorio;
        }

        public async Task<IEnumerable<ParcelasEmprestimo>> Handle(GetParcelasEmprestimoPeloEmprestimoIdQuery request, CancellationToken cancellationToken)
        {
            return await _parcelasEmprestimoRepositorio.GetPeloEmprestimoIdAsync(request.Id);
        }
    }
}
