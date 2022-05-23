using App.ContaCorrente.Application.CQRS.SaldoContaCorrentes.Queries;
using App.ContaCorrente.Application.DTOs;
using App.ContaCorrente.Application.Servicos.Interfaces;
using App.ContaCorrente.Domain.Entidades;
using App.ContaCorrente.Domain.Mensagem;
using App.ContaCorrente.Domain.Validacoes;
using AutoMapper;
using MediatR;

namespace App.ContaCorrente.Application.Servicos
{
    public class SaldoContaCorrenteServico : ISaldoContaCorrenteServico
    {

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public SaldoContaCorrenteServico(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<SaldoContaCorrenteDTO> GetPeloCorrentistaIdAsync(int? id)
        {
            var saldoQuery = new GetSaldoContaCorrentePeloCorrentistaIdQuery(id.Value);

            if(saldoQuery == null)
            {
                throw new DomainException(String.Format(Mensagens.EntidadeNaoCarregada, nameof(SaldoContaCorrente)));
            }

            var result = await _mediator.Send(saldoQuery);

            return _mapper.Map<SaldoContaCorrenteDTO>(result);
        }

        public async Task<SaldoContaCorrenteDTO> GetPeloIdAsync(int? id)
        {
            var saldoQuery = new GetSaldoContaCorrentePeloIdQuery(id.Value);

            if (saldoQuery == null)
            {
                throw new DomainException(String.Format(Mensagens.EntidadeNaoCarregada, nameof(SaldoContaCorrente)));
            }

            var result = await _mediator.Send(saldoQuery);

            return _mapper.Map<SaldoContaCorrenteDTO>(result);
        }
    }
}
