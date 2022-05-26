using App.ContaCorrente.Application.CQRS.Correntistas.Commands;
using App.ContaCorrente.Domain.Entidades;
using App.ContaCorrente.Domain.Interfaces;
using App.ContaCorrente.Domain.Mensagem;
using App.ContaCorrente.Domain.Validacoes;
using MediatR;

namespace App.ContaCorrente.Application.CQRS.Correntistas.Handlers
{
    public class CorrentistaAlterarCommandHandler : IRequestHandler<CorrentistaAlterarCommand, Correntista>
    {
        private readonly ICorrentistaRepositorio _correntistaRepositorio;
        private readonly ILocalTrabalhoRepositorio _localTrabalhoRepositorio;        
        public CorrentistaAlterarCommandHandler(ICorrentistaRepositorio correntistaRepositorio, ILocalTrabalhoRepositorio localTrabalhoRepositorio)
        {
            _correntistaRepositorio = correntistaRepositorio;
            _localTrabalhoRepositorio = localTrabalhoRepositorio;            
        }
        public async Task<Correntista> Handle(CorrentistaAlterarCommand request, CancellationToken cancellationToken)
        {
            var correntista = await _correntistaRepositorio.GetPeloIdAsync(request.Id);
            
            var locaTrabalho = await _localTrabalhoRepositorio.GetPeloIdAsync(request.LocalTrabalhoId);            

            if(locaTrabalho == null)
            {
                throw new DomainException(Mensagens.LocalTrabalhoInvalido);
            }

            if (correntista == null)
            {
                throw new DomainException(String.Format(Mensagens.EntidadeNaoCarregada,nameof(Correntista)));
            }
            else
            {
                correntista.Atualizar(correntista.Agencia,correntista.Conta,request.DataInicio,request.DataEncerramento,request.FlagConta,correntista.PessoaId,request.LocalTrabalhoId);

                return await _correntistaRepositorio.AlterarAsync(correntista);
            }
        }
    }
}
