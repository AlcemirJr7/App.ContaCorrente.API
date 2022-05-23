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
    public class EnderecoAlterarCommandHandler : IRequestHandler<EnderecoAlterarCommand, Endereco>
    {
        private readonly IEnderecoRepositorio _enderecoRepositorio;
        public EnderecoAlterarCommandHandler(IEnderecoRepositorio enderecoRepositorio)
        {
            _enderecoRepositorio = enderecoRepositorio;
        }
        public async Task<Endereco> Handle(EnderecoAlterarCommand request, CancellationToken cancellationToken)
        {
            var endereco = await _enderecoRepositorio.GetPeloIdAsync(request.Id);
            
            if (endereco == null)
            {
                throw new DomainException(String.Format(Mensagens.EntidadeNaoCarregada,nameof(Endereco)));
            }
            else
            {
                endereco.Atualizar(request.Cep, request.NomeRua, request.NumeroRua, request.Complemento, request.Bairro, request.Cidade, request.Estado, request.Sigla);

                return await _enderecoRepositorio.AlterarAsync(endereco);
                
            }

        }
    }
}
