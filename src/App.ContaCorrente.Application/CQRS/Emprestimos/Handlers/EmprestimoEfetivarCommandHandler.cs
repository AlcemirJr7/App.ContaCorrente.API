using App.ContaCorrente.Application.CQRS.Emprestimos.Commands;
using App.ContaCorrente.Application.Servicos.Interfaces;
using App.ContaCorrente.Domain.Entidades;
using App.ContaCorrente.Domain.Enumerador;
using App.ContaCorrente.Domain.Interfaces;
using App.ContaCorrente.Domain.Mensagem;
using App.ContaCorrente.Domain.Validacoes;
using AutoMapper;
using MediatR;

namespace App.ContaCorrente.Application.CQRS.Emprestimos.Handlers
{
    public class EmprestimoEfetivarCommandHandler : IRequestHandler<EmprestimoEfetivarCommand, Emprestimo>
    {
        private readonly IEmprestimoRepositorio _emprestimoRepositorio;
        private readonly IEmprestimoServico _emprestimoServico;
        private readonly IParcelasEmprestimoServico _parcelasEmprestimoServico;
        private readonly IParcelasEmprestimoRepositorio _parcelasEmprestimoRepositorio;
        private readonly ILancamentoRepositorio _lancamentoRepositorio;
        private readonly ISaldoContaCorrenteServico _saldoContaCorrenteServico;
        private readonly IMapper _mapper;        
        public EmprestimoEfetivarCommandHandler(IEmprestimoRepositorio emprestimoRepositorio, IEmprestimoServico emprestimoServico,
                                                IParcelasEmprestimoServico parcelasEmprestimoServico, IParcelasEmprestimoRepositorio parcelasEmprestimoRepositorio,
                                                IMapper mapper, ILancamentoRepositorio lancamentoRepositorio, ISaldoContaCorrenteServico saldoContaCorrenteServico)
        {
            _emprestimoRepositorio = emprestimoRepositorio;
            _emprestimoServico = emprestimoServico;
            _parcelasEmprestimoServico = parcelasEmprestimoServico;
            _parcelasEmprestimoRepositorio = parcelasEmprestimoRepositorio;
            _lancamentoRepositorio = lancamentoRepositorio;
            _saldoContaCorrenteServico = saldoContaCorrenteServico;
            _mapper = mapper;
            
        }

        public async Task<Emprestimo> Handle(EmprestimoEfetivarCommand request, CancellationToken cancellationToken)
        {
            var emprestimo = await _emprestimoRepositorio.GetPeloIdAsync(request.Id);
            
            if (emprestimo == null)
            {
                throw new DomainException(Mensagens.ErroAoCriarEntidade);
            }
            
            try
            {
                
                var saldoDevedor = emprestimo.ValorParcela * emprestimo.QtdParcelas;

                var analiseOk = await _emprestimoServico.AnaliseCreditoCorrentistaAsync(emprestimo.CorrentistaId, emprestimo.ValorParcela);

                if (analiseOk)
                {
                    
                    emprestimo.AtualizarEfetivacao(emprestimo.Valor,EnumEmprestimoStatus.EmAberto, saldoDevedor, emprestimo.TipoFinalidade,emprestimo.TipoEmprestimo,
                                                   emprestimo.QtdParcelas,emprestimo.ValorParcela,emprestimo.Juros,DateTime.Now,null, EnumFlagEstadoEmprestimo.Efetivado,
                                                   EnumProcessoEmprestimo.Aprovado,emprestimo.CorrentistaId);
                    
                    //efetivo eperstimo
                    var resultEmprestimo = await _emprestimoRepositorio.AlterarAsync(emprestimo);

                    //Gera parcelas 
                    var result = _parcelasEmprestimoServico.GerarParcelasEmprestimo(resultEmprestimo);

                    var parcelas = _mapper.Map<IEnumerable<ParcelasEmprestimo>>(result);

                    //Cria as parcelas
                    await _parcelasEmprestimoRepositorio.CriarAsync(parcelas);

                    
                    var lancamento = new Lancamento(DateTime.Now,emprestimo.Valor,$"Crédito emprestimo: {emprestimo.Id}",emprestimo.CorrentistaId,
                                                    (int)EnumEmprestimoHistorico.CreditoEmConta);

                    //criar lançamento
                    await _lancamentoRepositorio.CriarAsync(lancamento);
                    

                    //atualiza o saldo                    
                    await _saldoContaCorrenteServico.AtulizaSaldoAsync(emprestimo.CorrentistaId,(int)EnumEmprestimoHistorico.CreditoEmConta,emprestimo.Valor);
                    

                    return resultEmprestimo;

                }
                else
                {
                    // caso analise não ok rejeitar o emprestimo
                    emprestimo.AtualizarEfetivacao(emprestimo.Valor,EnumEmprestimoStatus.EmAberto,decimal.Zero,emprestimo.TipoFinalidade, emprestimo.TipoEmprestimo, 
                                                   emprestimo.QtdParcelas, emprestimo.ValorParcela, emprestimo.Juros,null,DateTime.Now, EnumFlagEstadoEmprestimo.Proposta, 
                                                   EnumProcessoEmprestimo.Rejeitado, emprestimo.CorrentistaId);
                                                            
                    return await _emprestimoRepositorio.AlterarAsync(emprestimo);
                }

            }
            catch(DomainException e)
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
