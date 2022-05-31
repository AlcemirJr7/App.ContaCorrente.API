    using App.ContaCorrente.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.ContaCorrente.Infra.Data.ConfiguracoesEntidades
{
    public class ChavePixConfiguracao : IEntityTypeConfiguration<ChavePix>
    {
        public void Configure(EntityTypeBuilder<ChavePix> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Chave).HasMaxLength(100);
        }
    }
}
