using App.ContaCorrente.Application.CQRS.Historicos.Commands;
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
    public class HistoricoCriarCommandHandler : IRequestHandler<HistoricoCriarCommand, Historico>
    {
        private readonly IHistoricoRepositorio _historicoRepositorio;
        public HistoricoCriarCommandHandler(IHistoricoRepositorio historicoRepositorio)
        {
            _historicoRepositorio = historicoRepositorio;                               
        }

        public async Task<Historico> Handle(HistoricoCriarCommand request, CancellationToken cancellationToken)
        {
            var historico = new Historico(request.Descricao, request.TipoDebitoCredito);

            if (historico == null)
            {                
                throw new DomainException(Mensagens.ErroAoCriarEntidade);
            }
            else
            {
                return await _historicoRepositorio.CriarAsync(historico);
            }

            
        }
    }
}
