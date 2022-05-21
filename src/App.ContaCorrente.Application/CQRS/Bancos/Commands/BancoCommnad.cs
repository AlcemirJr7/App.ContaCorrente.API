using App.ContaCorrente.Domain.Entidades;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ContaCorrente.Application.CQRS.Bancos.Commands
{
    public abstract class BancoCommnad : IRequest<Banco>
    {
        public int Id { get; protected set; }

        public string Nome { get; private set; }

        public string NomeCompleto { get; private set; }
    }
}
