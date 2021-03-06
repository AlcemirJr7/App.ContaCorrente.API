using App.ContaCorrente.Application.CQRS.Bancos.Queries;
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

namespace App.ContaCorrente.Application.CQRS.Bancos.Handlers
{
    public class GetBancosPeloIdQueryHandler : IRequestHandler<GetBancosPeloIdQuery, Banco>
    {
        private readonly IBancoRepositorio _bancoRepositorio;
        public GetBancosPeloIdQueryHandler(IBancoRepositorio bancoRepositorio)
        {
            _bancoRepositorio = bancoRepositorio;
        }
        public async Task<Banco> Handle(GetBancosPeloIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await _bancoRepositorio.GetBancosPeloIdAsync(request.Id);
            }
            catch 
            {
                throw new DomainException(Mensagens.ErroAoEfetuarConsulta);
            }
            
        }
    }
}
