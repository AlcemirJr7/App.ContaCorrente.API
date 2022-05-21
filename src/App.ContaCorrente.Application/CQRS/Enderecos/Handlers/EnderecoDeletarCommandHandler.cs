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
    public class EnderecoDeletarCommandHandler : IRequestHandler<EnderecoDeletarCommand, Endereco>
    {
        private readonly IEnderecoRepositorio _enderecoRepositorio;
        public EnderecoDeletarCommandHandler(IEnderecoRepositorio enderecoRepositorio)
        {
            _enderecoRepositorio = enderecoRepositorio;
        }

        public async Task<Endereco> Handle(EnderecoDeletarCommand request, CancellationToken cancellationToken)
        {
            var endereco = await _enderecoRepositorio.GetPeloIdAsync(request.Id);

            if (endereco == null)
            {
                throw new DomainException(Mensagens.EntidadeNaoCarregada);
            }

            return await _enderecoRepositorio.DeletarAsync(endereco);            
        }
    }
}
