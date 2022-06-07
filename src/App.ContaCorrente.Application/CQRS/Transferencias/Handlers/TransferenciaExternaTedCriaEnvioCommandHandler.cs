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
    public class TransferenciaExternaTedCriaEnvioCommandHandler : IRequestHandler<TransferenciaExternaTedCriaEnvioCommand, Transferencia>
    {
        private readonly ITransferenciaRepositorio _transferenciaRepositorio;
        private readonly ICorrentistaRepositorio _correntistaRepositorio;
        private readonly ISaldoContaCorrenteServico _saldoContaCorrenteServico;
        private readonly ILancamentoRepositorio _lancamentoRepositorio;

        public TransferenciaExternaTedCriaEnvioCommandHandler(ITransferenciaRepositorio transferenciaRepositorio, ICorrentistaRepositorio correntistaRepositorio,
                                                              ISaldoContaCorrenteServico saldoContaCorrenteServico, ILancamentoRepositorio lancamentoRepositorio)
        {
            _transferenciaRepositorio = transferenciaRepositorio;
            _correntistaRepositorio = correntistaRepositorio;   
            _saldoContaCorrenteServico = saldoContaCorrenteServico;
            _lancamentoRepositorio = lancamentoRepositorio;
        }

        public async Task<Transferencia> Handle(TransferenciaExternaTedCriaEnvioCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var correntista = await _correntistaRepositorio.GetPeloIdAsync(request.CorrentistaEnviaId);

                if(correntista == null)
                {
                    throw new DomainException(Mensagens.CorrentistaInvalido);
                }

                var transferenciaExterna = new TransferenciaExternaTed(DateTime.Now,request.Valor,DateTime.Now,EnumTransferenciaModo.Externa,EnumTransferenciaTipo.Ted,null,
                                                                       correntista.Id,request.CodigoBancoExterno,request.CodigoAgenciaEterno,request.NumeroContaExtero,
                                                                       request.NomePessoaExtero,request.NumeroDocumentoExterno);

                var transferenciaExternaCriada = await _transferenciaRepositorio.CriarAsync(transferenciaExterna);

                await _saldoContaCorrenteServico.ValidaSaldoAsync(correntista.Id,(int)EnumTransferenciaExternaHistoricoTed.EnviaTed,transferenciaExternaCriada.Valor);

                var lancamento = new Lancamento(DateTime.Now,transferenciaExternaCriada.Valor, "Envio Externo Transferencia Ted ID:" + transferenciaExternaCriada.Id,
                                                correntista.Id, (int)EnumTransferenciaExternaHistoricoTed.EnviaTed);

                var lancamentoCriado = await _lancamentoRepositorio.CriarAsync(lancamento);

                await _saldoContaCorrenteServico.AtulizaSaldoAsync(lancamentoCriado.CorrentistaId, (int)EnumTransferenciaExternaHistoricoTed.EnviaTed,lancamentoCriado.Valor);

                return transferenciaExternaCriada;

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
                throw new DomainException(Mensagens.ErroAoEnviarTransacaoTedExterna);
            }
        }
    }
}
