using App.ContaCorrente.Application.CQRS.Pessoas.Queries;
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
    public class GetPessoaPeloIdQueryHandler : IRequestHandler<GetPessoaPeloIdQuery, Pessoa>
    {
        private readonly IPessoaRepositorio _pessoaRepositorio;
        public GetPessoaPeloIdQueryHandler(IPessoaRepositorio pessoaRepositorio)
        {
            _pessoaRepositorio = pessoaRepositorio;
        }
        public async Task<Pessoa> Handle(GetPessoaPeloIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await _pessoaRepositorio.GetPeloIdAsync(request.Id);
            }
            catch 
            {
                throw new DomainException(Mensagens.ErroAoEfetuarConsulta);
            }
        }
    }
}
