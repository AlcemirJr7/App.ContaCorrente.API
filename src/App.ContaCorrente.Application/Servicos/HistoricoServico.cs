using App.ContaCorrente.Application.CQRS.Historicos.Commands;
using App.ContaCorrente.Application.DTOs;
using App.ContaCorrente.Application.Servicos.Interfaces;
using App.ContaCorrente.Domain.Entidades;
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

        public Task AlterarAsync(HistoricoDTO historicoDto)
        {
            throw new NotImplementedException();
        }        

        public async Task CriarAsync(HistoricoDTO historicoDto)
        {
            var historicoCriarCommand = _mapper.Map<HistoricoCriarCommand>(historicoDto);
            await _mediator.Send(historicoCriarCommand);
        }        

        public Task<IEnumerable<HistoricoDTO>> GetHistoricosAsync()
        {
            throw new NotImplementedException();
        }

        public Task<HistoricoDTO> GetPeloIdAsync(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
