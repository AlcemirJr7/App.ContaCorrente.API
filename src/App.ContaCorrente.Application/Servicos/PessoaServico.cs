using App.ContaCorrente.Application.CQRS.Pessoas.Commands;
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
    public class PessoaServico : IPessoaServico
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public PessoaServico(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;   
        }

        public async Task<Pessoa> AlterarAsync(PessoaDTO pessoaDto)
        {
            throw new NotImplementedException();
        }

        public async Task<Pessoa> CriarAsync(PessoaDTO pessoaDto)
        {
            var pessoaCriarCommand = _mapper.Map<PessoaCriarCommand>(pessoaDto);
            return await _mediator.Send(pessoaCriarCommand);   
        }

        public async Task<PessoaDTO> GetPeloIdAsync(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
