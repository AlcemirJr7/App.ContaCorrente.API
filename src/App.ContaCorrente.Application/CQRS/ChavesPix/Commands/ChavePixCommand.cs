using App.ContaCorrente.Domain.Entidades;
using App.ContaCorrente.Domain.Enumerador;
using MediatR;

namespace App.ContaCorrente.Application.CQRS.ChavesPix.Commands
{
    public abstract class ChavePixCommand : IRequest<ChavePix>
    {
        public int Id { get; set; }

        public string? Chave { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime? DataInativacao { get; set; }

        public EnumChavePixTipo TipoChave { get; set; }

        public EnumChavePixSituacao Situacao { get; set; }

        public int CorrentistaId { get; set; }

    }
}
