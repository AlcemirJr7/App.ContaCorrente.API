using App.ContaCorrente.Application.CQRS.ChavesPix.Commands;
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

        public Task<ChavePixDTO> AlterarAsync(ChavePixDTO chavePixDto)
        {
            throw new NotImplementedException();
        }

        public async Task<ChavePixDTO> CriarAsync(ChavePixDTO chavePixDto)
        {
            var chavePixCommand = _mapper.Map<ChavePixCriarCommand>(chavePixDto);

            var result = await _mediator.Send(chavePixCommand);

            return _mapper.Map<ChavePixDTO>(result);

        }

        public Task<ChavePixDTO> GetChavePixPelaChaveAsync(string? chave)
        {
            throw new NotImplementedException();
        }

        public Task<ChavePixDTO> GetChavePixPeloCorrentistaIdAsync(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
