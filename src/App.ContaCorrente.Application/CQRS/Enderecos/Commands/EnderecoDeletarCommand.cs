using App.ContaCorrente.Domain.Entidades;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ContaCorrente.Application.CQRS.Enderecos.Commands
{
    public class EnderecoDeletarCommand : IRequest<Endereco>
    {
        public int Id { get; set; }
        public EnderecoDeletarCommand(int id)
        {
            Id = id;
        }
    }
}
