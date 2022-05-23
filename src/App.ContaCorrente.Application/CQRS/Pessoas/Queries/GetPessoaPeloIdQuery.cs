using App.ContaCorrente.Domain.Entidades;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ContaCorrente.Application.CQRS.Pessoas.Queries
{
    public class GetPessoaPeloIdQuery : IRequest<Pessoa>
    {
        public int Id { get; set; }
        public GetPessoaPeloIdQuery(int id)
        {
            Id = id;
        }
    }
}

