using App.ContaCorrente.Application.CQRS.LocalTrabalhoPessoas.Commands;
using App.ContaCorrente.Application.DTOs;
using App.ContaCorrente.Application.Servicos.Interfaces;
using AutoMapper;
using MediatR;

namespace App.ContaCorrente.Application.Servicos
{
    public class LocalTrabalhoServico : ILocalTrabalhoServico
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public LocalTrabalhoServico(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;   
        }

        public async Task AlterarAsync(LocalTrabalhoDTO localTrabalhoPessoaDto)
        {
            throw new NotImplementedException();
        }

        public async Task CriarAsync(LocalTrabalhoDTO localTrabalhoDto)
        {
            var localTrabalhoCriarCommand = _mapper.Map<LocalTrabalhoCriarCommand>(localTrabalhoDto);
            await _mediator.Send(localTrabalhoCriarCommand);
        }
        
        public async Task<LocalTrabalhoDTO> GetPeloIdAsync(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
