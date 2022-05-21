using App.ContaCorrente.Domain.Entidades;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ContaCorrente.Application.CQRS.Enderecos.Queries
{
    public class GetEnderecoPeloIdQuery : IRequest<Endereco>
    {
        public int Id { get; set; }
        public GetEnderecoPeloIdQuery(int id)
        {
            Id = id;
        }
    }
}
