using App.ContaCorrente.Application.CQRS.Enderecos.Queries;
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
    public class GetEnderecoPeloIdQueryHandler : IRequestHandler<GetEnderecoPeloIdQuery, Endereco>
    {
        private readonly IEnderecoRepositorio _enderecoRepositorio;
        public GetEnderecoPeloIdQueryHandler(IEnderecoRepositorio enderecoRepositorio)
        {
            _enderecoRepositorio = enderecoRepositorio;                
        }
        public async Task<Endereco> Handle(GetEnderecoPeloIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await _enderecoRepositorio.GetPeloIdAsync(request.Id); ;
            }
            catch 
            {
                throw new DomainException(Mensagens.ErroAoEfetuarConsulta);
            }
            

        }
    }
}
