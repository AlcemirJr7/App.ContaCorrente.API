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

        public Task<Historico> AlterarAsync(Historico historico)
        {
            throw new NotImplementedException();
        }        

        public Task<Historico> CriarAsync(Historico historico)
        {
            throw new NotImplementedException();
        }        

        public Task<IEnumerable<Historico>> GetHistoricosAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Historico> GetPeloIdAsync(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
