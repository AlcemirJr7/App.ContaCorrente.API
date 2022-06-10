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

        public async Task<TransferenciaInternaPixDTO> CriarPixInternoAsync(TransferenciaInternaPixDTO transferenciaDto)
        {
            var transferenciaCommand = _mapper.Map<TransferenciaInternaPixCriarCommand>(transferenciaDto);

            var result = await _mediator.Send(transferenciaCommand);

            return _mapper.Map<TransferenciaInternaPixDTO>(result);

        }
        public async Task<TransferenciaInternaPixAgendaDTO> CriarPixInternoAgendamentoAsync(TransferenciaInternaPixAgendaDTO transferenciaDto)
        {
            var transferenciaCommand = _mapper.Map<TransferenciaInternaPixCriarAgendamentoCommand>(transferenciaDto);

            var result = await _mediator.Send(transferenciaCommand);

            return _mapper.Map<TransferenciaInternaPixAgendaDTO>(result);

        }

        public async Task<TransferenciaExternaEnviaPixDTO> CriarPixExternoEnvioAsync(TransferenciaExternaEnviaPixDTO transferenciaDto)
        {
            var transferenciaCommand = _mapper.Map<TransferenciaExternaPixCriarEnvioCommand>(transferenciaDto);

            var result = await _mediator.Send(transferenciaCommand);

            return _mapper.Map<TransferenciaExternaEnviaPixDTO>(result);

        }

        public async Task<TransferenciaExternaEnviaTedDTO> CriarTedExternoEnvioAsync(TransferenciaExternaEnviaTedDTO transferenciaDto)
        {
            var transferenciaCommand = _mapper.Map<TransferenciaExternaTedCriaEnvioCommand>(transferenciaDto);

            var result = await _mediator.Send(transferenciaCommand);

            return _mapper.Map<TransferenciaExternaEnviaTedDTO>(result);

        }

        public async Task<TransferenciaInternaTedDTO> CriarTedInternoAsync(TransferenciaInternaTedDTO transferenciaDto)
        {
            var transferenciaCommand = _mapper.Map<TransferenciaInternaTedCriarCommand>(transferenciaDto);

            var result = await _mediator.Send(transferenciaCommand);

            return _mapper.Map<TransferenciaInternaTedDTO>(result);

        }

        public Task<TransferenciaInternaPixDTO> GetPeloIdAsync(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
