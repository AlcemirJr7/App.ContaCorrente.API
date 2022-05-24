using App.ContaCorrente.Application.CQRS.Enderecos.Commands;
using App.ContaCorrente.Application.CQRS.Enderecos.Queries;
using App.ContaCorrente.Application.DTOs;
using App.ContaCorrente.Application.Servicos.Interfaces;
using App.ContaCorrente.Domain.Entidades;
using App.ContaCorrente.Domain.Mensagem;
using App.ContaCorrente.Domain.Validacoes;
using AutoMapper;
using MediatR;


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

        public async Task<EnderecoDTO> AlterarAsync(EnderecoDTO enderecoDto)
        {
            var enderecoAlterarCommand = _mapper.Map<EnderecoAlterarCommand>(enderecoDto);            
            var result = await _mediator.Send(enderecoAlterarCommand);
            var endereco = _mapper.Map<EnderecoDTO>(result);

            return endereco;
        }

        public async Task<EnderecoDTO> CriarAsync(EnderecoDTO enderecoDto)
        {
            var enderecoCriarCommand = _mapper.Map<EnderecoCriarCommand>(enderecoDto);
            var result = await _mediator.Send(enderecoCriarCommand);
            var endereco = _mapper.Map<EnderecoDTO>(result);

            return endereco;
        }

        public async Task<EnderecoDTO> DeletarAsync(int? id)
        {
            var enderecoDeletarCommand = new EnderecoDeletarCommand(id.Value);

            if(enderecoDeletarCommand == null)
            {
                throw new DomainException(Mensagens.EntidadeNaoCarregada);
            }

            var resutl = await _mediator.Send(enderecoDeletarCommand);
            var endereco = _mapper.Map<EnderecoDTO>(resutl);

            return endereco;

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
