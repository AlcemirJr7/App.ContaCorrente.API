using App.ContaCorrente.Application.CQRS.Transferencias.Commands;
using App.ContaCorrente.Domain.Entidades;
using App.ContaCorrente.Domain.Entidades.Transferencias;
using App.ContaCorrente.Domain.Enumerador;
using App.ContaCorrente.Domain.Interfaces;
using App.ContaCorrente.Domain.Mensagem;
using App.ContaCorrente.Domain.Validacoes;
using MediatR;

namespace App.ContaCorrente.Application.CQRS.Transferencias.Handlers
{
    public class TransferenciaInternaPixCriarAgendamentoCommandHandler : IRequestHandler<TransferenciaInternaPixCriarAgendamentoCommand, Transferencia>
    {
        private readonly ITransferenciaRepositorio _transferenciaRepositorio;
        private readonly ILancamentoFuturoRepositorio _lancamentoFuturoRepositorio;
        private readonly IChavePixRepositorio _chavePixRepositorio;
        public TransferenciaInternaPixCriarAgendamentoCommandHandler(ITransferenciaRepositorio transferenciaRepositorio, 
                                                                     ILancamentoFuturoRepositorio lancamentoFuturoRepositorio, IChavePixRepositorio chavePixRepositorio)
        {
            _transferenciaRepositorio = transferenciaRepositorio;
            _lancamentoFuturoRepositorio = lancamentoFuturoRepositorio;
            _chavePixRepositorio = chavePixRepositorio;
        }

        public async Task<Transferencia> Handle(TransferenciaInternaPixCriarAgendamentoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var chavePixEnvia = await _chavePixRepositorio.GetChavePixAtivaPelaChaveAsync(request.ChavePixEnvia);

                if(chavePixEnvia == null)
                {
                    throw new DomainException(Mensagens.ChavePixEnviaInvalido);
                }

                var chavePixRecebe = await _chavePixRepositorio.GetChavePixAtivaPelaChaveAsync(request.ChavePixRecebe);

                if(chavePixRecebe == null)
                {
                    throw new DomainException(Mensagens.ChavePixRecebeInvalido);
                }

                var transferencia = new TransferenciaInterna(null,request.Valor,DateTime.Now,EnumTransferenciaModo.Interna,EnumTransferenciaTipo.Pix,request.DataAgendamento,
                                                             request.ChavePixRecebe,request.ChavePixEnvia,null,null,chavePixRecebe.CorrentistaId,chavePixEnvia.CorrentistaId);

                var transferenciaCriada = await _transferenciaRepositorio.CriarAsync(transferencia);

                var lancamentoFuturoEnvio = new LancamentoFuturo(transferenciaCriada.Valor,DateTime.Now,request.DataAgendamento.GetValueOrDefault(),EnumTipoLancamentoFuturo.Transferencia,
                                                            EnumLancamentoFuturo.Pendente,null,"Agendamento transferencia envio interna Pix",transferenciaCriada.Id,
                                                            EnumSituacaoLancamentoFuturo.Ativo,(int)EnumTransferenciaInternaHistoricoPix.EnviaPix,chavePixEnvia.CorrentistaId);

                var lancamentoFuturoRecebe = new LancamentoFuturo(transferenciaCriada.Valor, DateTime.Now, request.DataAgendamento.GetValueOrDefault(), EnumTipoLancamentoFuturo.Transferencia,
                                                            EnumLancamentoFuturo.Pendente, null, "Agendamento transferencia recebimento interna Pix", transferenciaCriada.Id,
                                                            EnumSituacaoLancamentoFuturo.Ativo, (int)EnumTransferenciaInternaHistoricoPix.RecebePix, chavePixRecebe.CorrentistaId);

                await _lancamentoFuturoRepositorio.CriarAsync(lancamentoFuturoEnvio);

                await _lancamentoFuturoRepositorio.CriarAsync(lancamentoFuturoRecebe);

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
            catch
            {
                throw new DomainException(Mensagens.ErroAoAgendarTransferenciaPixInterno);
            }
        }
    }
}
