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
    public class GetBancosQueryHandler : IRequestHandler<GetBancosQuery, IEnumerable<Banco>>
    {
        private readonly IBancoRepositorio _bancoRepositorio;
        public GetBancosQueryHandler(IBancoRepositorio bancoRepositorio)
        {
            _bancoRepositorio = bancoRepositorio;
        }

        public async Task<IEnumerable<Banco>> Handle(GetBancosQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await _bancoRepositorio.GetBancosAsync();
            }
            catch 
            {
                throw new DomainException(Mensagens.ErroAoEfetuarConsulta);                
            }
            
        }
    }
}
