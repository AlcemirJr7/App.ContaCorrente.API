using App.ContaCorrente.Application.CQRS.Transferencias.Commands;
using App.ContaCorrente.Application.Servicos.Interfaces;
using App.ContaCorrente.Domain.Entidades;
using App.ContaCorrente.Domain.Entidades.Transferencias;
using App.ContaCorrente.Domain.Enumerador;
using App.ContaCorrente.Domain.Interfaces;
using App.ContaCorrente.Domain.Mensagem;
using App.ContaCorrente.Domain.Validacoes;
using MediatR;
using System.ComponentModel;

namespace App.ContaCorrente.Application.CQRS.Transferencias.Handlers
{
    public class TransferenciaInternaTedCriarCommandHandler : IRequestHandler<TransferenciaInternaTedCriarCommand, Transferencia>
    {
        private readonly ITransferenciaRepositorio _transferenciaRepositorio;
        private readonly ICorrentistaRepositorio _correntistaRepositorio;
        private readonly ILancamentoRepositorio _lancamentoRepositorio;
        private readonly ISaldoContaCorrenteServico _saldoContaCorrenteServico;
        public TransferenciaInternaTedCriarCommandHandler(ITransferenciaRepositorio transferenciaRepositorio, ICorrentistaRepositorio correntistaRepositorio,
                                                          ILancamentoRepositorio lancamentoRepositorio, ISaldoContaCorrenteServico saldoContaCorrenteServico)
        {
            _transferenciaRepositorio = transferenciaRepositorio;
            _correntistaRepositorio = correntistaRepositorio;   
            _lancamentoRepositorio = lancamentoRepositorio;
            _saldoContaCorrenteServico = saldoContaCorrenteServico;
        }

        public async Task<Transferencia> Handle(TransferenciaInternaTedCriarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var agenciaInt = (int)EnumAgencia.Agencia;
                var agencia = agenciaInt.ToString().PadLeft(4,'0');

                var banco = (int)EnumBanco.Banco;

                var correntistaRecebe = await _correntistaRepositorio.GetPelaContaAgenciaBancoAsync(banco, agencia, request.NumeroContaRecebe);

                if (correntistaRecebe == null)
                {
                    throw new DomainException(Mensagens.EntidadeNaoEncontrada + " Correntista Recebe.");
                }

                var correntistaEnvia = await _correntistaRepositorio.GetPelaContaAgenciaBancoAsync(banco, agencia, request.NumeroContaEnvia);

                if (correntistaEnvia == null)
                {
                    throw new DomainException(Mensagens.EntidadeNaoEncontrada + " Correntista Envia.");
                }

                var transferencia = new TransferenciaInterna(DateTime.Now,request.Valor,DateTime.Now,EnumTransferenciaModo.Interna,EnumTransferenciaTipo.Ted,
                                                             null,null,null,correntistaRecebe.Conta,correntistaEnvia.Conta,correntistaRecebe.Id,correntistaEnvia.Id);

                var transferenciaCriada = await _transferenciaRepositorio.CriarAsync(transferencia);

                // valida envio
                await _saldoContaCorrenteServico.ValidaSaldoAsync(correntistaEnvia.Id, (int)EnumTransferenciaInternaHistoricoTed.EnviaTed, transferenciaCriada.Valor);

                // lancamento envio
                var lancamentoEnvio = new Lancamento(DateTime.Now,transferenciaCriada.Valor,"Envio Ted Transferencia ID:" + transferenciaCriada.Id,
                                                     correntistaEnvia.Id, (int)EnumTransferenciaInternaHistoricoTed.EnviaTed);

                await _lancamentoRepositorio.CriarAsync(lancamentoEnvio);

                //atualiza saldo envio
                await _saldoContaCorrenteServico.AtulizaSaldoAsync(correntistaEnvia.Id, (int)EnumTransferenciaInternaHistoricoTed.EnviaTed, transferenciaCriada.Valor);


                //valida recebimento
                await _saldoContaCorrenteServico.ValidaSaldoAsync(correntistaRecebe.Id, (int)EnumTransferenciaInternaHistoricoTed.RecebeTed,transferenciaCriada.Valor);

                // lancamento recebe
                var lancamentoRecebe = new Lancamento(DateTime.Now,transferenciaCriada.Valor,"Recebimento Ted Transferencia ID:" + transferenciaCriada.Id,
                                                      correntistaRecebe.Id, (int)EnumTransferenciaInternaHistoricoTed.RecebeTed);

                await _lancamentoRepositorio.CriarAsync(lancamentoRecebe);

                //atualiza saldo revebe
                await _saldoContaCorrenteServico.AtulizaSaldoAsync(correntistaRecebe.Id, (int)EnumTransferenciaInternaHistoricoTed.RecebeTed, transferenciaCriada.Valor);

                return transferenciaCriada;


            }
            catch (DomainException e)
            {
                throw new DomainException(e.Message);
            }
            catch (DomainExcepitonValidacao e)
            {
                throw new DomainExcepitonValidacao(e.Message);
            }
        }
    }
}
