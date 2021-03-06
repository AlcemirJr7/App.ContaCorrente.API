using App.ContaCorrente.Application.CQRS.LocalTrabalhos.Commands;
using App.ContaCorrente.Application.CQRS.LocalTrabalhos.Queries;
using App.ContaCorrente.Application.DTOs;
using App.ContaCorrente.Application.Servicos.Interfaces;
using App.ContaCorrente.Domain.Entidades;
using App.ContaCorrente.Domain.Mensagem;
using App.ContaCorrente.Domain.Validacoes;
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

        public async Task<LocalTrabalhoDTO> AlterarAsync(LocalTrabalhoDTO localTrabalhoDto)
        {
            var localTrabalhoAlterarCommand = _mapper.Map<LocalTrabalhoAlterarCommand>(localTrabalhoDto);
            var result =  await _mediator.Send(localTrabalhoAlterarCommand);
            var localTrabalho = _mapper.Map<LocalTrabalhoDTO>(result);

            return localTrabalho;
        }

        public async Task<LocalTrabalhoDTO> CriarAsync(LocalTrabalhoDTO localTrabalhoDto)
        {
            var localTrabalhoCriarCommand = _mapper.Map<LocalTrabalhoCriarCommand>(localTrabalhoDto);
            var result =  await _mediator.Send(localTrabalhoCriarCommand);
            var localTrabalho = _mapper.Map<LocalTrabalhoDTO>(result);

            return localTrabalho;
        }
        
        public async Task<LocalTrabalhoDTO> GetPeloIdAsync(int? id)
        {
            var localTrabalhoQuery = new GetLocalTrabalhoPeloIdQuery(id.Value);

            if(localTrabalhoQuery == null)
            {
                throw new DomainException(String.Format(Mensagens.EntidadeNaoCarregada,nameof(LocalTrabalho)));
            }

            var result = await _mediator.Send(localTrabalhoQuery);

            return _mapper.Map<LocalTrabalhoDTO>(result);

        }
    }
}
