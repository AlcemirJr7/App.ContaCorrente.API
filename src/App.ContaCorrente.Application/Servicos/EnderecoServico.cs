using App.ContaCorrente.Application.CQRS.Enderecos.Commands;
using App.ContaCorrente.Application.CQRS.Enderecos.Queries;
using App.ContaCorrente.Application.DTOs;
using App.ContaCorrente.Application.Servicos.Interfaces;
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
    public class EnderecoServico : IEnderecoServico
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public EnderecoServico(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;            
        }

        public Task<EnderecoDTO> AlterarAsync(EnderecoDTO enderecoDto)
        {
            throw new NotImplementedException();
        }

        public async Task CriarAsync(EnderecoDTO enderecoDto)
        {
            var enderecoCriarCommand = _mapper.Map<EnderecoCriarCommand>(enderecoDto);
            await _mediator.Send(enderecoCriarCommand);
        }

        public Task<EnderecoDTO> DeletarAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public async Task<EnderecoDTO> GetPeloIdAsync(int? id)
        {
            var enderecoQuery = new GetEnderecoPeloIdQuery(id.Value);

            if(enderecoQuery == null)
            {
                throw new DomainException(Mensagens.ErroAoEfetuarConsulta);
            }
            else
            {
                var result = await _mediator.Send(enderecoQuery);

                return _mapper.Map<EnderecoDTO>(result);
            }
            
        }
    }
}
