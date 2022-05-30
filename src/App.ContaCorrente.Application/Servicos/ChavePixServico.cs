using App.ContaCorrente.Application.CQRS.ChavesPix.Commands;
using App.ContaCorrente.Application.CQRS.ChavesPix.Queries;
using App.ContaCorrente.Application.DTOs;
using App.ContaCorrente.Application.Servicos.Interfaces;
using AutoMapper;
using MediatR;

namespace App.ContaCorrente.Application.Servicos
{
    public class ChavePixServico : IChavePixServico
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public ChavePixServico(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;   
            _mapper = mapper;
        }

        public async Task<ChavePixDTO> AlterarAsync(int? correntistaId)
        {
            var chavePixCommand = new ChavePixInativarCommand { CorrentistaId = correntistaId.Value };

            var result = await _mediator.Send(chavePixCommand);

            return _mapper.Map<ChavePixDTO>(result);
        }

        public async Task<ChavePixDTO> CriarAsync(ChavePixDTO chavePixDto)
        {
            var chavePixCommand = _mapper.Map<ChavePixCriarCommand>(chavePixDto);

            var result = await _mediator.Send(chavePixCommand);

            return _mapper.Map<ChavePixDTO>(result);

        }

        public async Task<ChavePixDTO> GetChavePixPelaChaveAsync(string? chave)
        {
            var chavePixQuery = new GetChavePixPelaChaveQuery(chave);

            var result = await _mediator.Send(chavePixQuery);

            return _mapper.Map<ChavePixDTO>(result);

        }

        public async Task<ChavePixDTO> GetChavePixPeloCorrentistaIdAsync(int? id)
        {
            var chavePixQuery = new GetChavePixPeloCorrentistaIdQuery(id.Value);

            var result = await _mediator.Send(chavePixQuery);

            return _mapper.Map<ChavePixDTO>(result);
        }
    }
}
