using App.ContaCorrente.Application.CQRS.LancamentosFuturos.Commands;
using App.ContaCorrente.Application.DTOs;
using App.ContaCorrente.Application.Servicos.Interfaces;
using AutoMapper;
using MediatR;

namespace App.ContaCorrente.Application.Servicos
{
    public class LancamentoFuturoServico : ILancamentoFuturoServico
    {

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public LancamentoFuturoServico(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public Task<LancamentoFuturoDTO> AlterarAsync(LancamentoFuturoDTO lancamentoFuturoDto)
        {
            throw new NotImplementedException();
        }

        public async Task<LancamentoFuturoDTO> CriarAsync(LancamentoFuturoDTO lancamentoFuturoDto)
        {
            var lancamentoFuturoCommand = _mapper.Map<LancamentoFuturoCriarCommand>(lancamentoFuturoDto);

            var result = await _mediator.Send(lancamentoFuturoCommand);

            var lancamentoFuturo = _mapper.Map<LancamentoFuturoDTO>(result);

            return lancamentoFuturo;

        }

        public Task<IEnumerable<LancamentoFuturoDTO>> GetPeloCorrentistaIdAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<LancamentoFuturoDTO> GetPeloIdAsync(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
