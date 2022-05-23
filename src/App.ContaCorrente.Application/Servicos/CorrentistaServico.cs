using App.ContaCorrente.Application.CQRS.Correntistas.Commands;
using App.ContaCorrente.Application.CQRS.Correntistas.Queries;
using App.ContaCorrente.Application.DTOs;
using App.ContaCorrente.Application.Servicos.Interfaces;
using App.ContaCorrente.Domain.Entidades;
using App.ContaCorrente.Domain.Interfaces;
using App.ContaCorrente.Domain.Mensagem;
using App.ContaCorrente.Domain.Validacoes;
using AutoMapper;
using MediatR;

namespace App.ContaCorrente.Application.Servicos
{
    public class CorrentistaServico : ICorrentistaServico
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ISaldoContaCorrenteRepositorio _saldoContaCorrenteRepositorio;
        public CorrentistaServico(IMediator mediator, IMapper mapper, ISaldoContaCorrenteRepositorio saldoContaCorrenteRepositorio)
        {
            _mediator = mediator;
            _mapper = mapper;   
            _saldoContaCorrenteRepositorio = saldoContaCorrenteRepositorio;
        }

        public async Task<Correntista> AlterarAsync(CorrentistaAlteraDTO correntistaDto)
        {
            var correntistaAlterarCommand = _mapper.Map<CorrentistaAlterarCommand>(correntistaDto);
            return await _mediator.Send(correntistaAlterarCommand);
        }

        public async Task<Correntista> CriarAsync(CorrentistaDTO correntistaDto)
        {
            var correntistaCriarCommand = _mapper.Map<CorrentistaCriarCommand>(correntistaDto);
            var correntista = await _mediator.Send(correntistaCriarCommand);

            // Criar Saldo do correntista
            var saldo = new SaldoContaCorrente(0,null,0,correntista.Id);
            await _saldoContaCorrenteRepositorio.CriarAsync(saldo);
            
            return correntista;

        }

        public Task<Correntista> GetPeloIdAsync(int? id)
        {
            var correntistaQuery = new GetCorrentistaPeloIdQuery(id.Value);

            if(correntistaQuery == null)
            {
                throw new DomainException(String.Format(Mensagens.EntidadeNaoCarregada, nameof(Correntista)));
            }

            var result = _mediator.Send(correntistaQuery);

            return result;

        }
        
    }
}
