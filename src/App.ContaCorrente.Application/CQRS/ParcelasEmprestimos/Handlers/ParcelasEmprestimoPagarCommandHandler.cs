using App.ContaCorrente.Application.CQRS.ParcelasEmprestimos.Commands;
using App.ContaCorrente.Application.Servicos.Interfaces;
using App.ContaCorrente.Domain.Entidades;
using App.ContaCorrente.Domain.Enumerador;
using App.ContaCorrente.Domain.Interfaces;
using App.ContaCorrente.Domain.Mensagem;
using App.ContaCorrente.Domain.Validacoes;
using MediatR;

namespace App.ContaCorrente.Application.CQRS.ParcelasEmprestimos.Handlers
{
    public class ParcelasEmprestimoPagarCommandHandler : IRequestHandler<ParcelasEmprestimoPagarCommand, IEnumerable<ParcelasEmprestimo>>
    {
        private readonly IEmprestimoRepositorio _emprestimoRepositorio;   
        private readonly IEmprestimoServico _emprestimoServico;
        private readonly IParcelasEmprestimoRepositorio _parcelasEmprestimoRepositorio;        
        private readonly ISaldoContaCorrenteServico _saldoContaCorrenteServico;
        private readonly ILancamentoRepositorio _lancamentoRepositorio;
        public ParcelasEmprestimoPagarCommandHandler(IEmprestimoRepositorio emprestimoRepositorio, IParcelasEmprestimoRepositorio parcelasEmprestimoRepositorio,
                                                     ISaldoContaCorrenteServico saldoContaCorrenteServico, ILancamentoRepositorio lancamentoRepositorio,
                                                     IEmprestimoServico emprestimoServico)
        {
            _emprestimoRepositorio = emprestimoRepositorio;
            _parcelasEmprestimoRepositorio = parcelasEmprestimoRepositorio;          
            _lancamentoRepositorio = lancamentoRepositorio;
            _saldoContaCorrenteServico = saldoContaCorrenteServico;
            _emprestimoServico = emprestimoServico;
        }

        public async Task<IEnumerable<ParcelasEmprestimo>> Handle(ParcelasEmprestimoPagarCommand request, CancellationToken cancellationToken)
        {
            var emprestimos = await _emprestimoRepositorio.GetEmprestimosEfetivadosEmAbertoAsync();

            List<ParcelasEmprestimo> listaParcelasPagas = new List<ParcelasEmprestimo>();
            try
            {
                foreach (var emprestimo in emprestimos)
                {
                    var ParcelasEmprestimo = await _parcelasEmprestimoRepositorio.GetParcelasAhVencerAsync(emprestimo.Id);

                    foreach (var parcela in ParcelasEmprestimo)
                    {
                        try
                        {
                            await _saldoContaCorrenteServico.ValidaSaldoAsync(emprestimo.CorrentistaId, (int)EnumParcelasEmprestimoHistorico.Historico, parcela.Valor);
                        }
                        catch
                        {
                            continue;
                        }

                        var lancamento = new Lancamento(DateTime.Now, parcela.Valor, $"Pagamento parcela: {parcela.SeqParcelas}  emprestimo ID: {emprestimo.Id}",
                                                        emprestimo.CorrentistaId, (int)EnumParcelasEmprestimoHistorico.Historico);

                        var lancamentoCriado = await _lancamentoRepositorio.CriarAsync(lancamento);

                        await _saldoContaCorrenteServico.AtulizaSaldoAsync(lancamentoCriado.CorrentistaId, lancamentoCriado.HistoricoId, lancamentoCriado.Valor);

                        parcela.Atualizar(parcela.Valor, parcela.SeqParcelas, parcela.DataVencimento, DateTime.Now, emprestimo.Id);

                        await _parcelasEmprestimoRepositorio.AlterarAsync(parcela);

                        await _emprestimoServico.AtualizaSaldoDevedor(parcela.Valor,emprestimo);

                        listaParcelasPagas.Add(parcela);

                    }
                }

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
                throw new DomainException(Mensagens.ErroAoProcessarPagamentoParcelasEmprestimo);
            }
            
            return listaParcelasPagas;

        }
    }
}
