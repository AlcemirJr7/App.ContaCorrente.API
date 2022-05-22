using App.ContaCorrente.Domain.Entidades;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ContaCorrente.Application.CQRS.Enderecos.Commands
{
    public abstract class EnderecoCommand : IRequest<Endereco>
    {
        public int Id { get; set; }

        public int Cep { get;  set; }

        public string NomeRua { get;  set; }

        public int NumeroRua { get; set; }

        public string? Complemento { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        public string Sigla { get; set; }
    }
}
