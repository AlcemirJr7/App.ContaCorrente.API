using App.ContaCorrente.Domain.Entidades;
using App.ContaCorrente.Domain.Enumerador;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace App.ContaCorrente.Application.CQRS.Correntistas.Commands
{
    public abstract class CorrentistaCommand : IRequest<Correntista>
    {        
        public int Id { get; set; }

        public string Agencia { get; set; }

        public string Conta { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime? DataEncerramento { get; set; }

        public EnumContaCorrente FlagConta { get; set; }

        public int PessoaId { get; set; }

        [JsonIgnore]
        public int BancoId { get; set; }

        public int? LocalTrabalhoId { get; set; }

    }
}
