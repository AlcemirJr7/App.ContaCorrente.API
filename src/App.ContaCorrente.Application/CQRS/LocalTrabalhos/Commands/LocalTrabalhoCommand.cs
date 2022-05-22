using App.ContaCorrente.Domain.Entidades;
using MediatR;


namespace App.ContaCorrente.Application.CQRS.LocalTrabalhoPessoas.Commands
{
    public abstract class LocalTrabalhoCommand : IRequest<LocalTrabalho>
    {
       
        public int Id { get; set; }

        public string NomeEmpresa { get; set; }

        public long NumeroDocumento { get; set; }

        public long NumeroTelefone1 { get; set; }

        public long? NumeroTelefone2 { get; set; }

        public string Email1 { get; set; }

        public string? Email2 { get; set; }

        public decimal Salario1 { get; set; }

        public decimal? Salario2 { get; set; }
        
        public DateTime DataCadastro { get; set; }
    }
}
