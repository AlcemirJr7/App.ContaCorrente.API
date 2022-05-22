using App.ContaCorrente.Domain.Entidades;
using App.ContaCorrente.Domain.Enumerador;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ContaCorrente.Application.CQRS.Pessoas.Commands
{
    public abstract class PessoaCommand : IRequest<Pessoa>
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string? NomeEmpresa { get; set; }

        public long NumeroDocumento { get; set; }

        public EnumPessoa TipoPessoa { get; set; }

        public long NumeroTelefone1 { get; set; }

        public long? NumeroTelefone2 { get; set; }

        public string Email1 { get; set; }

        public string? Email2 { get; set; }

        public DateTime DataNascimento { get; set; }

        public DateTime DataCadastro { get; set; }

        public int EnderecoId { get; set; }
    }
}
