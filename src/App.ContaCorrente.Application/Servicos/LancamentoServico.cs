using App.ContaCorrente.Application.CQRS.Lancamentos.Commands;
using App.ContaCorrente.Application.CQRS.Lancamentos.Queries;
using App.ContaCorrente.Application.DTOs;
using App.ContaCorrente.Application.Servicos.Interfaces;
using App.ContaCorrente.Domain.Entidades;
using App.ContaCorrente.Domain.Mensagem;
using App.ContaCorrente.Domain.Validacoes;
using AutoMapper;
using MediatR;

namespace App.ContaCorrente.Application.Servicos
{
    public class LancamentoServico : ILancamentoServico
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;        
        public LancamentoServico(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;            
        }

        public async Task<LancamentoDTO> CriarAsync(LancamentoDTO lancamentoDto)
        {
            
            var lancamentoCriarCommand = _mapper.Map<LancamentoCriarCommand>(lancamentoDto);
                                
            var result = await _mediator.Send(lancamentoCriarCommand);

            var lancamento = _mapper.Map<LancamentoDTO>(result);

            return lancamento;
        }

        public async Task<IEnumerable<LancamentoDTO>> GetPeloCorrentistaIdAsync(int? id)
        {
            var lancamentosQuery = new GetLancamentosPeloCorrentistaIdQuery(id.Value);

            if (lancamentosQuery == null)
            {
                throw new DomainException(String.Format(Mensagens.EntidadeNaoCarregada, nameof(Lancamento)));
            }

            var result = await _mediator.Send(lancamentosQuery);

            return _mapper.Map<IEnumerable<LancamentoDTO>>(result);
        }

        public async Task<LancamentoDTO> GetPeloIdAsync(int? id)
        {
            var lancamentoQuery = new GetLancamentoPeloIdQuery(id.Value);

            if (lancamentoQuery == null)
            {
                throw new DomainException(String.Format(Mensagens.EntidadeNaoCarregada, nameof(Pessoa)));
            }

            var result = await _mediator.Send(lancamentoQuery);

            return _mapper.Map<LancamentoDTO>(result);
        }
        
    }
}
