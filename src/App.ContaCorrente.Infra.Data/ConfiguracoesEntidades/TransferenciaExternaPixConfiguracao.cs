using App.ContaCorrente.Domain.Entidades.Transferencias;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.ContaCorrente.Infra.Data.ConfiguracoesEntidades
{
    public class TransferenciaExternaPixConfiguracao : IEntityTypeConfiguration<TransferenciaExternaPix>
    {
        public void Configure(EntityTypeBuilder<TransferenciaExternaPix> builder)
        {
            builder.Property(t => t.ChavePixEnviaExterno).HasMaxLength(100).HasColumnName("ChavePixEnviaExterno");
            builder.Property(t => t.ChavePixRecebeExterno).HasMaxLength(100).HasColumnName("ChavePixRecebeExterno");
            builder.Property(t => t.CorrentistaEnviaId).HasPrecision(10).HasColumnName("CorrentistaEnviaId");
            builder.Property(t => t.CorrentistaRecebeId).HasPrecision(10).HasColumnName("CorrentistaRecebeId");
            builder.Property(t => t.ChavePixEnvia).HasMaxLength(100).HasColumnName("ChavePixEnvia");
            builder.Property(t => t.ChavePixRecebe).HasMaxLength(100).HasColumnName("ChavePixRecebe");

        }
    }
}
