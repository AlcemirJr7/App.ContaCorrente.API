using App.ContaCorrente.Application.CQRS.Pessoas.Commands;
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

namespace App.ContaCorrente.Application.CQRS.Pessoas.Handlers
{
    public class PessoaAlterarCommandHandler : IRequestHandler<PessoaAlterarCommand, Pessoa>
    {
        private readonly IPessoaRepositorio _pessoaRepositorio;
        private readonly IEnderecoRepositorio _enderecoRepositorio;
        public PessoaAlterarCommandHandler(IPessoaRepositorio pessoaRepositorio, IEnderecoRepositorio enderecoRepositorio)
        {
            _pessoaRepositorio = pessoaRepositorio;
            _enderecoRepositorio = enderecoRepositorio;
        }
        public async Task<Pessoa> Handle(PessoaAlterarCommand request, CancellationToken cancellationToken)
        {

            var pessoa = await _pessoaRepositorio.GetPeloIdAsync(request.Id);

            if (pessoa == null)
            {
                throw new DomainException(String.Format(Mensagens.EntidadeNaoCarregada, nameof(Pessoa)));
            }
            else
            {
                var endereco = await _enderecoRepositorio.GetPeloIdAsync(request.EnderecoId);

                if(endereco == null)
                {
                    throw new DomainException(Mensagens.EnderecoInvalido);
                }

                pessoa.Atualizar(request.Nome,request.NomeEmpresa,request.NumeroDocumento,request.TipoPessoa,request.NumeroTelefone1,request.NumeroTelefone2,
                                 request.Email1, request.Email2,request.DataNascimento,request.EnderecoId);

                return await _pessoaRepositorio.AlterarAsync(pessoa);
            }
        }
    }
}
