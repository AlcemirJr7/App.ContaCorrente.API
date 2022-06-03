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
    public class TransferenciaExternaPixCriarEnvioCommandHandler : IRequestHandler<TransferenciaExternaPixCriarEnvioCommand, Transferencia>
    {
        private readonly ITransferenciaRepositorio _transferenciaRepositorio;
        private readonly IChavePixRepositorio _chavePixRepositorio;
        private readonly ISaldoContaCorrenteServico _saldoContaCorrenteServico;
        private readonly ILancamentoRepositorio _lancamentoRepositorio;
        public TransferenciaExternaPixCriarEnvioCommandHandler(ITransferenciaRepositorio transferenciaRepositorio, IChavePixRepositorio chavePixRepositorio,
                                                               ISaldoContaCorrenteServico saldoContaCorrenteServico, ILancamentoRepositorio lancamentoRepositorio)
        {
            _transferenciaRepositorio = transferenciaRepositorio;
            _chavePixRepositorio = chavePixRepositorio; 
            _saldoContaCorrenteServico = saldoContaCorrenteServico;
            _lancamentoRepositorio = lancamentoRepositorio;
        }

        public async Task<Transferencia> Handle(TransferenciaExternaPixCriarEnvioCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var chaveEnviaPix = await _chavePixRepositorio.GetChavePixAtivaPelaChaveAsync(request.ChavePixEnvia);

                if(chaveEnviaPix == null)
                {
                    throw new DomainException(Mensagens.ChavePixEnviaInvalido);
                }

                var transferenciaExterna = new TransferenciaExternaPix(DateTime.Now,request.Valor,DateTime.Now,EnumTransferenciaModo.Externa,EnumTransferenciaTipo.Pix,
                                                                       null,null,chaveEnviaPix.Chave,request.ChavePixRecebeExterno,null,null,chaveEnviaPix.CorrentistaId,
                                                                       request.TipoChave);

                var transferenciaCriadaExterna = await _transferenciaRepositorio.CriarAsync(transferenciaExterna);

                await _saldoContaCorrenteServico.ValidaSaldoAsync(chaveEnviaPix.CorrentistaId,(int)EnumTransferenciaExternaHistoricoPix.EnviaPix,transferenciaCriadaExterna.Valor);

                var lancamento = new Lancamento(DateTime.Now,transferenciaCriadaExterna.Valor,"Envio Externo Transferencia Pix ID:" + transferenciaCriadaExterna.Id,
                                                chaveEnviaPix.CorrentistaId,(int)EnumTransferenciaExternaHistoricoPix.EnviaPix);

                await _lancamentoRepositorio.CriarAsync(lancamento);

                await _saldoContaCorrenteServico.AtulizaSaldoAsync(lancamento.CorrentistaId, (int)EnumTransferenciaExternaHistoricoPix.EnviaPix, lancamento.Valor);

                return transferenciaCriadaExterna;
                
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
                throw new DomainException(Mensagens.ErroAoEnviarTransacaoPixExterna);
            }
    }
    }
}
