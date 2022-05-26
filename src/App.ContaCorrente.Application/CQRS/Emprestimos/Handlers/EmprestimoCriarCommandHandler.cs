using App.ContaCorrente.Application.CQRS.Emprestimos.Commands;
using App.ContaCorrente.Domain.Entidades;
using App.ContaCorrente.Domain.Enumerador;
using App.ContaCorrente.Domain.Interfaces;
using App.ContaCorrente.Domain.Mensagem;
using App.ContaCorrente.Domain.Validacoes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ContaCorrente.Application.CQRS.Emprestimos.Handlers
{
    public class EmprestimoCriarCommandHandler : IRequestHandler<EmprestimoCriarCommand, Emprestimo>
    {
        private readonly IEmprestimoRepositorio _emprestimoRepositorio;
        private readonly ICorrentistaRepositorio _correntistaRepositorio;
        public EmprestimoCriarCommandHandler(IEmprestimoRepositorio emprestimoRepositorio, ICorrentistaRepositorio correntistaRepositorio)
        {
            _emprestimoRepositorio = emprestimoRepositorio;
            _correntistaRepositorio = correntistaRepositorio;   
        }

        public async Task<Emprestimo> Handle(EmprestimoCriarCommand request, CancellationToken cancellationToken)
        {

            var correntista = await _correntistaRepositorio.GetPeloIdAsync(request.CorrentistaId);
            
            if(correntista == null)
            {
                throw new DomainException(Mensagens.CorrentistaInvalido);
            }


            var emprestimo = new Emprestimo(request.Valor,EnumEmprestimoStatus.EmAberto,decimal.Zero,request.TipoFinalidade,request.TipoEmprestimo,request.QtdParcelas,decimal.Zero,
                                            request.Juros,request.DataEfetivacao,DateTime.Now,EnumFlagEstadoEmprestimo.Proposta,
                                            EnumProcessoEmprestimo.EmAnalise,request.CorrentistaId);

            if(emprestimo == null)
            {
                throw new DomainException(String.Format(Mensagens.EntidadeNaoCarregada, nameof(Emprestimo)));
            }
            else
            {
                return await _emprestimoRepositorio.CriarAsync(emprestimo);
            }
           
        }
    }
}
