using App.ContaCorrente.Application.CQRS.Emprestimos.Commands;
using App.ContaCorrente.Application.Servicos.Interfaces;
using App.ContaCorrente.Domain.Entidades;
using App.ContaCorrente.Domain.Enumerador;
using App.ContaCorrente.Domain.Interfaces;
using App.ContaCorrente.Domain.Mensagem;
using App.ContaCorrente.Domain.Validacoes;
using MediatR;

namespace App.ContaCorrente.Application.CQRS.Emprestimos.Handlers
{
    public class EmprestimoEfetivarCommandHandler : IRequestHandler<EmprestimoEfetivarCommand, Emprestimo>
    {
        private readonly IEmprestimoRepositorio _emprestimoRepositorio;
        private readonly IEmprestimoServico _emprestimoServico;
        
        public EmprestimoEfetivarCommandHandler(IEmprestimoRepositorio emprestimoRepositorio, IEmprestimoServico emprestimoServico)
        {
            _emprestimoRepositorio = emprestimoRepositorio;
            _emprestimoServico = emprestimoServico;
        }

        public async Task<Emprestimo> Handle(EmprestimoEfetivarCommand request, CancellationToken cancellationToken)
        {
            var emprestimo = await _emprestimoRepositorio.GetPeloIdAsync(request.Id);
            
            if (emprestimo == null)
            {
                throw new DomainException(Mensagens.ErroAoCriarEntidade);
            }

            var valorParcela = decimal.Zero;

            try
            {
                valorParcela = _emprestimoServico.CalculaParcelaEmprestimo(emprestimo.Valor, emprestimo.QtdParcelas, emprestimo.Juros);

                var analiseOk = await _emprestimoServico.AnaliseCreditoCorrentistaAsync(emprestimo.CorrentistaId,valorParcela);

                if (analiseOk)
                {
                    

                    emprestimo.AtualizarEfetivacao(emprestimo.Valor,emprestimo.TipoFinalidade,emprestimo.TipoEmprestimo,emprestimo.QtdParcelas,valorParcela,emprestimo.Juros,
                                         DateTime.Now, EnumFlagEstadoEmprestimo.Efetivado,EnumProcessoEmprestimo.Aprovado,emprestimo.CorrentistaId);

                    var resultEmprestimo = await _emprestimoRepositorio.AlterarAsync(emprestimo);

                    //criar parcelas depois

                    //criar lançamento

                    return resultEmprestimo;

                }
                else
                {
                    
                    emprestimo.AtualizarEfetivacao(emprestimo.Valor, emprestimo.TipoFinalidade, emprestimo.TipoEmprestimo, emprestimo.QtdParcelas, valorParcela, emprestimo.Juros,
                                                DateTime.Now, EnumFlagEstadoEmprestimo.Proposta, EnumProcessoEmprestimo.Rejeitado, emprestimo.CorrentistaId);
                                                            
                    return await _emprestimoRepositorio.AlterarAsync(emprestimo);
                }

            }
            catch(DomainException e)
            {
                throw new DomainException(Mensagens.ErroAoEfetivarEmprestimo);
            }
            catch(DomainExcepitonValidacao e)
            {
                throw new DomainExcepitonValidacao(e.Message);
            }
        }
    }
}
