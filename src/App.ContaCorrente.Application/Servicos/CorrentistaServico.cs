using App.ContaCorrente.Application.CQRS.Correntistas.Commands;
using App.ContaCorrente.Application.DTOs;
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
    public class CorrentistaServico : ICorrentistaServico
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public CorrentistaServico(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;   
        }

        public async Task<Correntista> AlterarAsync(CorrentistaAlteraDTO correntistaDto)
        {
            var correntistaAlterarCommand = _mapper.Map<CorrentistaAlterarCommand>(correntistaDto);
            return await _mediator.Send(correntistaAlterarCommand);
        }

        public async Task<Correntista> CriarAsync(CorrentistaDTO correntistaDto)
        {
            var correntistaCriarCommand = _mapper.Map<CorrentistaCriarCommand>(correntistaDto);
            return await _mediator.Send(correntistaCriarCommand);
        }

        public Task<CorrentistaDTO> GetPeloIdAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<CorrentistaDTO> GetPeloPessoaIdAsync(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
