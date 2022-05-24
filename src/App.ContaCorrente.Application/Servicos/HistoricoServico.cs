using App.ContaCorrente.Application.CQRS.Historicos.Commands;
using App.ContaCorrente.Application.CQRS.Historicos.Queries;
using App.ContaCorrente.Application.DTOs;
using App.ContaCorrente.Application.Servicos.Interfaces;
using App.ContaCorrente.Domain.Entidades;
using App.ContaCorrente.Domain.Mensagem;
using App.ContaCorrente.Domain.Validacoes;
using AutoMapper;
using MediatR;

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

        public async Task<HistoricoDTO> AlterarAsync(HistoricoDTO historicoDto)
        {
            var historicoAlterarCommand = _mapper.Map<HistoricoAlterarCommand>(historicoDto);
            var result = await _mediator.Send(historicoAlterarCommand);
            var historico = _mapper.Map<HistoricoDTO>(result);

            return historico;   
        }        

        public async Task<HistoricoDTO> CriarAsync(HistoricoDTO historicoDto)
        {
            var historicoCriarCommand = _mapper.Map<HistoricoCriarCommand>(historicoDto);
            var result = await _mediator.Send(historicoCriarCommand);
            var historico = _mapper.Map<HistoricoDTO>(result);

            return historico;
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
