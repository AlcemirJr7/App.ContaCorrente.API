using App.ContaCorrente.Application.CQRS.LancamentosFuturos.Queries;
using App.ContaCorrente.Domain.Entidades;
using App.ContaCorrente.Domain.Interfaces;
using App.ContaCorrente.Domain.Mensagem;
using App.ContaCorrente.Domain.Validacoes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ContaCorrente.Application.CQRS.LancamentosFuturos.Handlers
{
    public class GetLancamentoFuturoPeloCorrentistaIdQueryHandler : IRequestHandler<GetLancamentoFuturoPeloCorrentistaIdQuery, IEnumerable<LancamentoFuturo>>
    {
        private readonly ILancamentoFuturoRepositorio _lancamentoFuturoRepositorio;
        public GetLancamentoFuturoPeloCorrentistaIdQueryHandler(ILancamentoFuturoRepositorio lancamentoFuturoRepositorio)
        {
            _lancamentoFuturoRepositorio = lancamentoFuturoRepositorio;
        }
        public async Task<IEnumerable<LancamentoFuturo>> Handle(GetLancamentoFuturoPeloCorrentistaIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await _lancamentoFuturoRepositorio.GetPeloCorrentistaIdAsync(request.Id);
            }
            catch
            {
                throw new DomainException(Mensagens.ErroAoEfetuarConsulta);
            }
        }
    }
}
