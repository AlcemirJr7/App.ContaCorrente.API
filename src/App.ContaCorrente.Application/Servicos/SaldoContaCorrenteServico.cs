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

        public async Task ValidaSaldoAsync(int correntistaId, int historicoId, decimal valor)
        {
            var temSaldo = false;

            var saldo = await _saldoContaCorrenteRepositorio.GetPeloCorrentistaIdAsync(correntistaId);
            
            if (saldo == null)
            {
                throw new DomainException(String.Format(Mensagens.EntidadeNaoCarregada, nameof(Correntista)));
            }            

            var historico = await _historicoRepositorio.GetPeloIdAsync(historicoId);

            if(historico == null)
            {
                throw new DomainException(String.Format(Mensagens.EntidadeNaoCarregada, nameof(Historico)));
            }
                        
            if(historico.TipoDebitoCredito == EnumHistoricoDebitoCredito.Credito)
            {
                temSaldo = true;
            }
            else
            {
                var saldoTotal = saldo.SaldoConta + saldo.LimiteChequeEspecial;

                if (valor > saldoTotal)
                {
                    temSaldo = false;
                }
                else
                {
                    temSaldo = true;
                }

                if (!temSaldo)
                {
                    throw new DomainException(Mensagens.SaldoInsuficiente);
                }
            }
                
            

        }

        public async Task AtulizaSaldoAsync(int correntistaId, int historicoId, decimal valor)
        {
            var saldo = await _saldoContaCorrenteRepositorio.GetPeloCorrentistaIdAsync(correntistaId);

            if (saldo == null)
            {
                throw new DomainException(String.Format(Mensagens.EntidadeNaoCarregada, nameof(SaldoContaCorrente)));
            }

            var historico = await _historicoRepositorio.GetPeloIdAsync(historicoId);

            if (historico == null)
            {
                throw new DomainException(String.Format(Mensagens.EntidadeNaoCarregada, nameof(Historico)));
            }
            
            decimal saltoAtualizado = 0;

            try
            {
                if(historico.TipoDebitoCredito == EnumHistoricoDebitoCredito.Credito)
                {
                    saltoAtualizado = (saldo.SaldoConta + valor);
                }
                else
                {
                    saltoAtualizado = (saldo.SaldoConta - valor);
                }

                saldo.Atualizar(saltoAtualizado,DateTime.Now,saldo.LimiteChequeEspecial,correntistaId);

                await _saldoContaCorrenteRepositorio.AlterarAsync(saldo);
                
            }
            catch 
            {
                throw new DomainException(Mensagens.ErroAoAtualizarSaldo);
            }
            

        }
    }
}
