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
    public class HistoricoAlterarCommandHandler : IRequestHandler<HistoricoAlterarCommand, Historico>
    {
        private readonly IHistoricoRepositorio _historicoRepositorio;
        public HistoricoAlterarCommandHandler(IHistoricoRepositorio historicoRepositorio)
        {
            _historicoRepositorio = historicoRepositorio;
        }
        public async Task<Historico> Handle(HistoricoAlterarCommand request, CancellationToken cancellationToken)
        {
            var historico = await _historicoRepositorio.GetPeloIdAsync(request.Id);

            if (historico == null)
            {
                throw new DomainException(String.Format(Mensagens.EntidadeNaoCarregada,nameof(Historico)));
            }
            else
            {
                historico.Atualizar(request.Descricao,request.TipoDebitoCredito);

                return await _historicoRepositorio.AlterarAsync(historico);
            }
        }
    }
}
