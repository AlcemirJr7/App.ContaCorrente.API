using App.ContaCorrente.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.ContaCorrente.Infra.Data.ConfiguracoesEntidades
{
    public class CorrentistaConfiguracao : IEntityTypeConfiguration<Correntista>
    {
        public void Configure(EntityTypeBuilder<Correntista> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Agencia).HasMaxLength(10).IsRequired();
            builder.Property(t => t.Conta).HasMaxLength(15).IsRequired();
        }
    }
}
