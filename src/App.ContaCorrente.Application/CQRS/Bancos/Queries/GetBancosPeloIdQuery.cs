using App.ContaCorrente.Domain.Entidades;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ContaCorrente.Application.CQRS.Bancos.Queries
{
    public class GetBancosPeloIdQuery : IRequest<Banco>
    {
        public int Id { get; set; }
        public GetBancosPeloIdQuery(int id)
        {
            Id = id;
        }
    }
}
