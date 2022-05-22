using App.ContaCorrente.Application.CQRS.Historicos.Queries;
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

namespace App.ContaCorrente.Application.CQRS.Historicos.Handlers
{
    public class GetHistoricosQueryHandler : IRequestHandler<GetHistoricosQuery, IEnumerable<Historico>>
    {
        private readonly IHistoricoRepositorio _historicoRepositorio;
        public GetHistoricosQueryHandler(IHistoricoRepositorio historicoRepositorio)
        {
            _historicoRepositorio = historicoRepositorio;
        }
        public async Task<IEnumerable<Historico>> Handle(GetHistoricosQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await _historicoRepositorio.GetHistoricosAsync();
            }
            catch
            {
                throw new DomainException(Mensagens.ErroAoEfetuarConsulta);
            }
        }
    }
}
