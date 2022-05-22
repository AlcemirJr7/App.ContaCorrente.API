using App.ContaCorrente.Application.CQRS.Bancos.Commands;
using App.ContaCorrente.Application.CQRS.Bancos.Queries;
using App.ContaCorrente.Application.DTOs;
using App.ContaCorrente.Application.Servicos.Interfaces;
using App.ContaCorrente.Domain.Entidades;
using App.ContaCorrente.Domain.Mensagem;
using App.ContaCorrente.Domain.Validacoes;
using AutoMapper;
using MediatR;

namespace App.ContaCorrente.Application.Servicos
{
    public class BancoServico : IBancoServico
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public BancoServico(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<Banco> AlterarAsync(BancoDTO bancoDto)
        {
            var bancoAlterarCommand = _mapper.Map<BancoAlterarCommnad>(bancoDto);
            return await _mediator.Send(bancoAlterarCommand);
        }

        public async Task<Banco> CriarAsync(BancoDTO bancoDto)
        {

            var bancoCriarCommand = _mapper.Map<BancoCriarCommnad>(bancoDto);
            return await _mediator.Send(bancoCriarCommand);
            
        }

        public async Task<BancoDTO> GetBancoPeloIdAsync(int? id)
        {
            var bancoQuery = new GetBancosPeloIdQuery(id.Value);

            if(bancoQuery == null)
            {
                throw new DomainException(Mensagens.EntidadeNaoCarregada);
            }

            var result = await _mediator.Send(bancoQuery);

            return _mapper.Map<BancoDTO>(result);
        }

        public async Task<IEnumerable<BancoDTO>> GetBancosAsync()
        {
            var bancoQuery = new GetBancosQuery();

            if(bancoQuery == null)
            {
                throw new DomainException(Mensagens.EntidadeNaoCarregada);
            }

            var result = await _mediator.Send(bancoQuery);

            return _mapper.Map<IEnumerable<BancoDTO>>(result);
        }
    }
}
