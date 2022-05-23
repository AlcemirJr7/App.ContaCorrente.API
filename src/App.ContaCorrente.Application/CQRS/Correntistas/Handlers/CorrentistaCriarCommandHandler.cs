using App.ContaCorrente.Application.CQRS.Correntistas.Commands;
using App.ContaCorrente.Domain.Entidades;
using App.ContaCorrente.Domain.Interfaces;
using App.ContaCorrente.Domain.Mensagem;
using App.ContaCorrente.Domain.Validacoes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ContaCorrente.Application.CQRS.Correntistas.Handlers
{
    public class CorrentistaCriarCommandHandler : IRequestHandler<CorrentistaCriarCommand, Correntista>
    {
        private readonly ICorrentistaRepositorio _correntistaRepositorio;
        public CorrentistaCriarCommandHandler(ICorrentistaRepositorio correntistaRepositorio)
        {
            _correntistaRepositorio = correntistaRepositorio;
        }

        public async Task<Correntista> Handle(CorrentistaCriarCommand request, CancellationToken cancellationToken)
        {
            var correntista = new Correntista(request.Agencia,request.Conta,request.DataInicio,request.DataEncerramento,request.FlagConta,request.PessoaId,request.BancoId,request.LocalTrabalhoId);

            if(correntista == null)
            {
                throw new DomainException(Mensagens.ErroAoCriarEntidade);
            }
            else
            {
                return await _correntistaRepositorio.CriarAsync(correntista);
            }
        }
    }
}
