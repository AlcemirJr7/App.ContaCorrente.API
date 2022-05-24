using App.ContaCorrente.Application.CQRS.SaldoContaCorrentes.Queries;
using App.ContaCorrente.Application.DTOs;
using App.ContaCorrente.Application.Servicos.Interfaces;
using App.ContaCorrente.Domain.Entidades;
using App.ContaCorrente.Domain.Enumerador;
using App.ContaCorrente.Domain.Interfaces;
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
        private readonly ISaldoContaCorrenteRepositorio _saldoContaCorrenteRepositorio;
        private readonly IHistoricoRepositorio _historicoRepositorio;

        public SaldoContaCorrenteServico(IMediator mediator, IMapper mapper, ISaldoContaCorrenteRepositorio saldoContaCorrenteRepositorio,
                                         IHistoricoRepositorio historicoRepositorio)
        {
            _mediator = mediator;
            _mapper = mapper;
            _historicoRepositorio = historicoRepositorio;
            _saldoContaCorrenteRepositorio = saldoContaCorrenteRepositorio;
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

        public async Task<bool> ValidaSaldo(LancamentoDTO lancamento)
        {
            var saldo = await _saldoContaCorrenteRepositorio.GetPeloCorrentistaIdAsync(lancamento.CorrentistaId);

            if (saldo == null)
            {
                throw new DomainException(String.Format(Mensagens.EntidadeNaoCarregada, nameof(SaldoContaCorrente)));
            }

            var historico = await _historicoRepositorio.GetPeloIdAsync(lancamento.HistoricoId);

            if(historico == null)
            {
                throw new DomainException(String.Format(Mensagens.EntidadeNaoCarregada, nameof(Historico)));
            }
                        
            if(historico.TipoDebitoCredito == EnumHistoricoDebitoCredito.Credito)
            {
                return true;
            }
                
            var saldoTotal = saldo.SaldoConta + saldo.LimiteChequeEspecial;

            if(lancamento.Valor > saldoTotal)
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }

        public async Task AtulizaSaldo(LancamentoDTO lancamento)
        {
            var saldo = await _saldoContaCorrenteRepositorio.GetPeloCorrentistaIdAsync(lancamento.CorrentistaId);

            if (saldo == null)
            {
                throw new DomainException(String.Format(Mensagens.EntidadeNaoCarregada, nameof(SaldoContaCorrente)));
            }

            var historico = await _historicoRepositorio.GetPeloIdAsync(lancamento.HistoricoId);

            if (historico == null)
            {
                throw new DomainException(String.Format(Mensagens.EntidadeNaoCarregada, nameof(Historico)));
            }

            var saldoTotal = saldo.SaldoConta + saldo.LimiteChequeEspecial.Value;

            decimal saltoAtualizado = 0;

            try
            {
                if(historico.TipoDebitoCredito == EnumHistoricoDebitoCredito.Credito)
                {
                    saltoAtualizado = (saldoTotal + lancamento.Valor);
                }
                else
                {
                    saltoAtualizado = (saldoTotal - lancamento.Valor);
                }

                saldo.Atualizar(saltoAtualizado,DateTime.Now,saldo.LimiteChequeEspecial,lancamento.CorrentistaId);

                await _saldoContaCorrenteRepositorio.AlterarAsync(saldo);
                
            }
            catch 
            {
                throw new DomainException(Mensagens.ErroAoAtualizarSaldo);
            }
            

        }
    }
}
