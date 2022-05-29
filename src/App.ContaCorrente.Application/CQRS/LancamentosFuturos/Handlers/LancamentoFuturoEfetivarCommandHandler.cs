using App.ContaCorrente.Application.CQRS.LancamentosFuturos.Commands;
using App.ContaCorrente.Application.Servicos.Interfaces;
using App.ContaCorrente.Domain.Entidades;
using App.ContaCorrente.Domain.Enumerador;
using App.ContaCorrente.Domain.Interfaces;
using App.ContaCorrente.Domain.Mensagem;
using App.ContaCorrente.Domain.Validacoes;
using MediatR;

namespace App.ContaCorrente.Application.CQRS.LancamentosFuturos.Handlers
{
    public class LancamentoFuturoEfetivarCommandHandler : IRequestHandler<LancamentoFuturoEfetivarCommand, IEnumerable<LancamentoFuturo>>
    {
        private readonly ILancamentoFuturoRepositorio _lancamentoFuturoRepositorio;
        private readonly ISaldoContaCorrenteServico _saldoContaCorrenteServico;
        private readonly ILancamentoFuturoServico _lancamentoFuturoServico;
        private readonly ILancamentoRepositorio _lancamentoRepositorio;
        public LancamentoFuturoEfetivarCommandHandler(ILancamentoFuturoRepositorio lancamentoFuturoRepositorio, ISaldoContaCorrenteServico saldoContaCorrenteServico,
                                                      ILancamentoFuturoServico lancamentoFuturoServico, ILancamentoRepositorio lancamentoRepositorio)
        {
            _lancamentoFuturoRepositorio = lancamentoFuturoRepositorio;
            _saldoContaCorrenteServico = saldoContaCorrenteServico;
            _lancamentoFuturoServico = lancamentoFuturoServico;
            _lancamentoRepositorio = lancamentoRepositorio;
        }

        public async Task<IEnumerable<LancamentoFuturo>> Handle(LancamentoFuturoEfetivarCommand request, CancellationToken cancellationToken)
        {
            var lancamentosFuturos = await _lancamentoFuturoRepositorio.GetLancamentosPendentesAsync();

            List <LancamentoFuturo> listaLancamentosFuturos = new List<LancamentoFuturo>();

            try
            {
                foreach (var lancamentoFuturo in lancamentosFuturos)
                {
                    
                    try
                    {
                        //valida o saldo
                        await _saldoContaCorrenteServico.ValidaSaldoAsync(lancamentoFuturo.CorrentistaId, lancamentoFuturo.HistoricoId, lancamentoFuturo.Valor);
                    }
                    catch 
                    {
                        //Caso não tenha saldo pula para o proximo lancamento
                        continue;
                    }

                    var lancamento = new Lancamento(DateTime.Now, lancamentoFuturo.Valor, lancamentoFuturo.Observacao, lancamentoFuturo.CorrentistaId, 
                                                    lancamentoFuturo.HistoricoId);

                    // Cria o lançamento
                    await _lancamentoRepositorio.CriarAsync(lancamento);
                    
                    //Atualiza o saldo
                    await _saldoContaCorrenteServico.AtulizaSaldoAsync(lancamento.CorrentistaId,lancamento.HistoricoId,lancamento.Valor);

                    switch (lancamentoFuturo.TipoLancamento)
                    {
                        case EnumTipoLancamentoFuturo.Pagamento:
                            await _lancamentoFuturoServico.AtualizaLancamentoFuturoPagamento(lancamentoFuturo.IdDoLancamento);
                            break;
                        case EnumTipoLancamentoFuturo.Emprestimo:
                            break;
                        case EnumTipoLancamentoFuturo.ParcelaEmprestimo:
                            break;
                        case EnumTipoLancamentoFuturo.Transferencia:
                            break;
                        case EnumTipoLancamentoFuturo.Outros:
                            break;
                        default:
                            break;
                    }

                    lancamentoFuturo.Atualizar(lancamentoFuturo.Valor,lancamentoFuturo.DataCadastro,lancamentoFuturo.DataParaLancamento,lancamentoFuturo.TipoLancamento,EnumLancamentoFuturo.Efetuado,
                                               DateTime.Now,lancamentoFuturo.Observacao,lancamentoFuturo.IdDoLancamento,EnumSituacaoLancamentoFuturo.Processado, lancamentoFuturo.HistoricoId,lancamentoFuturo.CorrentistaId);

                    var result = await _lancamentoFuturoRepositorio.AlterarAsync(lancamentoFuturo);

                    listaLancamentosFuturos.Add(result);

                }

                return listaLancamentosFuturos;
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
                throw new DomainException(Mensagens.ErroAoEfetivarLancamentosFuturos);
            }            
            
        }
    }
}
