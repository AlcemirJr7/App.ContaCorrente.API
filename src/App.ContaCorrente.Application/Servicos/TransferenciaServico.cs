using App.ContaCorrente.Application.CQRS.Transferencias.Commands;
using App.ContaCorrente.Application.DTOs;
using App.ContaCorrente.Application.Servicos.Interfaces;
using AutoMapper;
using MediatR;

namespace App.ContaCorrente.Application.Servicos
{
    public class TransferenciaServico : ITransferenciaServico
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public TransferenciaServico(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;

        }

        public Task<TransferenciaInternaPixDTO> AlterarAsync(TransferenciaInternaPixDTO transferenciaDto)
        {
            throw new NotImplementedException();
        }

        public async Task<TransferenciaInternaPixDTO> CriarPixAsync(TransferenciaInternaPixDTO transferenciaDto)
        {
            var transferenciaCommand = _mapper.Map<TransferenciaInternaPixCriarCommand>(transferenciaDto);

            var result = await _mediator.Send(transferenciaCommand);

            return _mapper.Map<TransferenciaInternaPixDTO>(result);

        }

        public Task<TransferenciaInternaPixDTO> GetPeloIdAsync(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
