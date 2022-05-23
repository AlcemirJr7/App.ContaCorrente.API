using App.ContaCorrente.Application.CQRS.Pessoas.Commands;
using App.ContaCorrente.Application.CQRS.Pessoas.Queries;
using App.ContaCorrente.Application.DTOs;
using App.ContaCorrente.Application.Servicos.Interfaces;
using App.ContaCorrente.Domain.Entidades;
using App.ContaCorrente.Domain.Mensagem;
using App.ContaCorrente.Domain.Validacoes;
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
            var pessoaAlterarCommand = _mapper.Map<PessoaAlterarCommand>(pessoaDto);
            return await _mediator.Send(pessoaAlterarCommand);
        }

        public async Task<Pessoa> CriarAsync(PessoaDTO pessoaDto)
        {
            var pessoaCriarCommand = _mapper.Map<PessoaCriarCommand>(pessoaDto);
            return await _mediator.Send(pessoaCriarCommand);   
        }

        public async Task<PessoaDTO> GetPeloIdAsync(int? id)
        {
            var pessoaQuery = new GetPessoaPeloIdQuery(id.Value);

            if(pessoaQuery == null)
            {
                throw new DomainException(String.Format(Mensagens.EntidadeNaoCarregada, nameof(Pessoa)));
            }

            var result = await _mediator.Send(pessoaQuery);

            return _mapper.Map<PessoaDTO>(result);

        }
    }
}
