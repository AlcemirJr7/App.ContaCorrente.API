using App.ContaCorrente.Application.CQRS.Emprestimos.Commands;
using App.ContaCorrente.Domain.Entidades;
using App.ContaCorrente.Domain.Interfaces;
using App.ContaCorrente.Domain.Mensagem;
using App.ContaCorrente.Domain.Validacoes;
using MediatR;

namespace App.ContaCorrente.Application.CQRS.Emprestimos.Handlers
{
    public class EmprestimoAlterarCommandHandler : IRequestHandler<EmprestimoAlterarCommand, Emprestimo>
    {
        private readonly IEmprestimoRepositorio _emprestimoRepositorio;
        private readonly ICorrentistaRepositorio _correntistaRepositorio;
        public EmprestimoAlterarCommandHandler(IEmprestimoRepositorio emprestimoRepositorio, ICorrentistaRepositorio correntistaRepositorio)
        {
            _emprestimoRepositorio = emprestimoRepositorio;
            _correntistaRepositorio = correntistaRepositorio;
        }

        public async Task<Emprestimo> Handle(EmprestimoAlterarCommand request, CancellationToken cancellationToken)
        {
            var correntista = await _correntistaRepositorio.GetPeloIdAsync(request.CorrentistaId);

            if (correntista == null)
            {
                throw new DomainException(Mensagens.CorrentistaInvalido);
            }

            var emprestimo = await _emprestimoRepositorio.GetPeloIdAsync(request.Id);

            if(emprestimo == null)
            {
                throw new DomainException(String.Format(Mensagens.EntidadeNaoCarregada, nameof(Emprestimo)));
            }
            else
            {                
                emprestimo.Atualizar(request.Valor,request.TipoFinalidade,request.TipoEmprestimo,request.QtdParcelas,decimal.Zero,request.Juros,request.DataEfetivacao,emprestimo.FlagEstado,emprestimo.FlagProcesso,request.CorrentistaId);

                return await _emprestimoRepositorio.AlterarAsync(emprestimo);
            }
                        
        }
    }
}
