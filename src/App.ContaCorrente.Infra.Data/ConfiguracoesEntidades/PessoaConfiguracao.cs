using App.ContaCorrente.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.ContaCorrente.Infra.Data.ConfiguracoesEntidades
{
    public class PessoaConfiguracao : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).HasMaxLength(200).IsRequired();
            builder.Property(x => x.NomeEmpresa).HasMaxLength(200);
            builder.Property(x => x.NumeroTelefone1).HasMaxLength(15).IsRequired();
            builder.Property(x => x.NumeroTelefone2).HasMaxLength(15);
            builder.Property(x => x.NumeroDocumento).HasMaxLength(20).IsRequired();
            builder.Property(x => x.Email1).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Email2).HasMaxLength(100);
            builder.Property(x => x.DataNascimento).HasColumnType("Date");

        }
    }
}
