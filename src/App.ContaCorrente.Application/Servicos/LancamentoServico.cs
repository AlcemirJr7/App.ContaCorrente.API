using App.ContaCorrente.Application.CQRS.Lancamentos.Commands;
using App.ContaCorrente.Application.DTOs;
using App.ContaCorrente.Application.Servicos.Interfaces;
using App.ContaCorrente.Domain.Entidades;
using App.ContaCorrente.Domain.Mensagem;
using App.ContaCorrente.Domain.Validacoes;
using AutoMapper;
using MediatR;

namespace App.ContaCorrente.Application.Servicos
{
    public class LancamentoServico : ILancamentoServico
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ISaldoContaCorrenteServico _saldoContaCorrenteServico; 
        public LancamentoServico(IMediator mediator, IMapper mapper, ISaldoContaCorrenteServico saldoContaCorrenteServico)
        {
            _mediator = mediator;
            _mapper = mapper;
            _saldoContaCorrenteServico = saldoContaCorrenteServico;
        }

        public async Task<Lancamento> CriarAsync(LancamentoDTO lancamentoDto)
        {
            var lancamentoCriarCommand = _mapper.Map<LancamentoCriarCommand>(lancamentoDto);

            var temSaldo = await _saldoContaCorrenteServico.ValidaSaldo(lancamentoDto);

            if (!temSaldo)
            {
                throw new DomainException(Mensagens.SaldoInsuficiente);
            }         
            
            var result = await _mediator.Send(lancamentoCriarCommand);
            
            await _saldoContaCorrenteServico.AtulizaSaldo(lancamentoDto);

            return result;
        }

        public Task<IEnumerable<LancamentoDTO>> GetPeloCorrentistaIdAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<LancamentoDTO> GetPeloIdAsync(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
