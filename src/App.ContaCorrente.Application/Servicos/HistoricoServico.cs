using App.ContaCorrente.Application.CQRS.Historicos.Commands;
using App.ContaCorrente.Application.CQRS.Historicos.Queries;
using App.ContaCorrente.Application.DTOs;
using App.ContaCorrente.Application.Servicos.Interfaces;
using App.ContaCorrente.Domain.Entidades;
using App.ContaCorrente.Domain.Mensagem;
using App.ContaCorrente.Domain.Validacoes;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ContaCorrente.Application.Servicos
{
    public class HistoricoServico : IHistoricoServico
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public HistoricoServico(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<Historico> AlterarAsync(HistoricoDTO historicoDto)
        {
            var historicoAlterarCommand = _mapper.Map<HistoricoAlterarCommand>(historicoDto);
            return await _mediator.Send(historicoAlterarCommand);
        }        

        public async Task<Historico> CriarAsync(HistoricoDTO historicoDto)
        {
            var historicoCriarCommand = _mapper.Map<HistoricoCriarCommand>(historicoDto);
            return await _mediator.Send(historicoCriarCommand);
        }        

        public async Task<IEnumerable<HistoricoDTO>> GetHistoricosAsync()
        {
            var historicosQuery = new GetHistoricosQuery();

            if (historicosQuery == null)
            {
                throw new DomainException(Mensagens.ErroAoCriarEntidade);
            }

            var result = await _mediator.Send(historicosQuery);

            return _mapper.Map<IEnumerable<HistoricoDTO>>(result);
        }

        public async Task<HistoricoDTO> GetPeloIdAsync(int? id)
        {
            var historicoQuery = new GetHistoricoPeloIdQuery(id.Value);

            if (historicoQuery == null)
            {
                throw new DomainException(Mensagens.ErroAoCriarEntidade);
            }
            
            var result = await _mediator.Send(historicoQuery);

            return _mapper.Map<HistoricoDTO>(result);   
        }
    }
}
