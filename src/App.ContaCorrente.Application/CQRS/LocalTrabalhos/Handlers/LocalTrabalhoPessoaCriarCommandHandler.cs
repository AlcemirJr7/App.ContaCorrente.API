using App.ContaCorrente.Application.CQRS.LocalTrabalhoPessoas.Commands;
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

namespace App.ContaCorrente.Application.CQRS.LocalTrabalhoPessoas.Handlers
{
    public class LocalTrabalhoPessoaCriarCommandHandler : IRequestHandler<LocalTrabalhoCriarCommand, LocalTrabalho>
    {
        private readonly ILocalTrabalhoRepositorio _localTrabalhoPessoaRepositorio;
        public LocalTrabalhoPessoaCriarCommandHandler(ILocalTrabalhoRepositorio localTrabalhoPessoaRepositorio)
        {
            _localTrabalhoPessoaRepositorio = localTrabalhoPessoaRepositorio;
        }

        public async Task<LocalTrabalho> Handle(LocalTrabalhoCriarCommand request, CancellationToken cancellationToken)
        {
            var localTrabalhoPessoa = new LocalTrabalho(request.NomeEmpresa,request.NumeroDocumento,request.NumeroTelefone1,request.NumeroTelefone2,
                                                              request.Email1,request.Email2,request.Salario1,request.Salario2);
            
            if(localTrabalhoPessoa == null)
            {
                throw new DomainException(Mensagens.ErroAoCriarEntidade);
            }
            else
            {
                localTrabalhoPessoa.DataCadastro = DateTime.Now;
                return await _localTrabalhoPessoaRepositorio.CriarAsync(localTrabalhoPessoa);
                
            }
        }
    }
}
