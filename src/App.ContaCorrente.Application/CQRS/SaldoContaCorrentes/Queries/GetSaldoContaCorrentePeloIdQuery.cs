using App.ContaCorrente.Domain.Entidades;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ContaCorrente.Application.CQRS.SaldoContaCorrentes.Queries
{
    public class GetSaldoContaCorrentePeloIdQuery : IRequest<SaldoContaCorrente>
    {
        public int Id { get; set; }
        public GetSaldoContaCorrentePeloIdQuery(int id)
        {
            Id = id;
        }
    }
}
