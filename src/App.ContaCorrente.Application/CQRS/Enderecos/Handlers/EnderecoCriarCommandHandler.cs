using App.ContaCorrente.Application.CQRS.Enderecos.Commands;
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

namespace App.ContaCorrente.Application.CQRS.Enderecos.Handlers
{
    public class EnderecoCriarCommandHandler : IRequestHandler<EnderecoCriarCommand, Endereco>
    {
        private readonly IEnderecoRepositorio _enderecoRepositorio;
        public EnderecoCriarCommandHandler(IEnderecoRepositorio enderecoRepositorio)
        {
            _enderecoRepositorio = enderecoRepositorio;
        }

        public async Task<Endereco> Handle(EnderecoCriarCommand request, CancellationToken cancellationToken)
        {
            var endereco = new Endereco(request.Cep,request.NomeRua,request.NumeroRua, request.Complemento,request.Bairro,request.Cidade,request.Estado,request.Sigla);

            if(endereco == null)
            {
                throw new DomainException(String.Format(Mensagens.EntidadeNaoCarregada,nameof(Endereco)));
            }
            else
            {                                            
                return await _enderecoRepositorio.CriarAsync(endereco); 
            }
        }
    }
}
