using App.ContaCorrente.Application.CQRS.Transferencias.Commands;
using App.ContaCorrente.Application.Servicos.Interfaces;
using App.ContaCorrente.Domain.Entidades;
using App.ContaCorrente.Domain.Entidades.Transferencias;
using App.ContaCorrente.Domain.Enumerador;
using App.ContaCorrente.Domain.Interfaces;
using App.ContaCorrente.Domain.Mensagem;
using App.ContaCorrente.Domain.Validacoes;
using MediatR;

namespace App.ContaCorrente.Application.CQRS.Transferencias.Handlers
{
    public class TransferenciaInternaPixCriarCommandHandler : IRequestHandler<TransferenciaInternaPixCriarCommand, Transferencia>
    {
        private readonly ITransferenciaRepositorio _transferenciaRepositorio;
        private readonly IChavePixRepositorio _chavePixRepositorio;
        private readonly ILancamentoRepositorio _lancamentoRepositorio;
        private readonly ISaldoContaCorrenteServico _saldoContaCorrenteServico;

        public TransferenciaInternaPixCriarCommandHandler(ITransferenciaRepositorio transferenciaRepositorio, IChavePixRepositorio chavePixRepositorio,
                                                          ILancamentoRepositorio lancamentoRepositorio, ISaldoContaCorrenteServico saldoContaCorrenteServico)
        {
            _transferenciaRepositorio = transferenciaRepositorio;
            _chavePixRepositorio = chavePixRepositorio; 
            _lancamentoRepositorio = lancamentoRepositorio;
            _saldoContaCorrenteServico = saldoContaCorrenteServico;
        }
        public async Task<Transferencia> Handle(TransferenciaInternaPixCriarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var chavePixRecebe = await _chavePixRepositorio.GetChavePixAtivaPelaChaveAsync(request.ChavePixRecebe);

                if(chavePixRecebe == null)
                {
                    throw new DomainException(Mensagens.ChavePixRecebeInvalido);
                }

                var chavePixEnvia = await _chavePixRepositorio.GetChavePixAtivaPelaChaveAsync(request.ChavePixEnvia);

                if (chavePixEnvia == null)
                {
                    throw new DomainException(Mensagens.ChavePixEnviaInvalido);
                }


                var transferencia = new TransferenciaInterna(DateTime.Now,request.Valor,DateTime.Now,EnumTransferenciaModo.Interna,EnumTransferenciaTipo.Pix,
                                                             request.DataAgendamento,request.ChavePixRecebe,request.ChavePixEnvia,null,null,
                                                             chavePixRecebe.CorrentistaId,chavePixEnvia.CorrentistaId);

                var transferenciaCriada = await _transferenciaRepositorio.CriarAsync(transferencia);

                try
                {
                    //valida receber
                    await _saldoContaCorrenteServico.ValidaSaldoAsync(chavePixRecebe.CorrentistaId,(int)EnumTransferenciaHistoricoPix.RecebePix,transferencia.Valor);
                }
                catch (DomainException e)
                {
                    throw new DomainException(e.Message);
                }

                try
                {
                    //valida envio
                    await _saldoContaCorrenteServico.ValidaSaldoAsync(chavePixEnvia.CorrentistaId, (int)EnumTransferenciaHistoricoPix.EnviaPix, transferenciaCriada.Valor);
                }
                catch (DomainException e)
                {
                    throw new DomainException(e.Message);
                }

                // lancamento recebe
                var lancamentoRecebe = new Lancamento(DateTime.Now, transferenciaCriada.Valor,"Recebimento Pix Transferencia ID:" + transferenciaCriada.Id.ToString(),
                                                chavePixRecebe.CorrentistaId, (int)EnumTransferenciaHistoricoPix.RecebePix);

                await _lancamentoRepositorio.CriarAsync(lancamentoRecebe);
                
                await _saldoContaCorrenteServico.AtulizaSaldoAsync(chavePixRecebe.CorrentistaId, (int)EnumTransferenciaHistoricoPix.RecebePix, lancamentoRecebe.Valor);


                // lancamento envia
                var lancamentoEnvia = new Lancamento(DateTime.Now, transferenciaCriada.Valor, "Envio Pix Transferencia ID:" + transferenciaCriada.Id.ToString(),
                                                    chavePixEnvia.CorrentistaId, (int)EnumTransferenciaHistoricoPix.RecebePix);

                await _lancamentoRepositorio.CriarAsync(lancamentoEnvia);

                await _saldoContaCorrenteServico.AtulizaSaldoAsync(chavePixEnvia.CorrentistaId, (int)EnumTransferenciaHistoricoPix.EnviaPix, lancamentoEnvia.Valor);

                return transferenciaCriada;

            }
            catch (DomainException e)
            {
                throw new DomainException(e.Message);
            }
            catch(DomainExcepitonValidacao e)
            {
                throw new DomainExcepitonValidacao(e.Message);
            }
        }
    }
}
