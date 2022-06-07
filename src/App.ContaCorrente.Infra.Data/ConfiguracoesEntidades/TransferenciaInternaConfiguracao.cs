using App.ContaCorrente.Domain.Entidades.Transferencias;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.ContaCorrente.Infra.Data.ConfiguracoesEntidades
{
    public class TransferenciaInternaConfiguracao : IEntityTypeConfiguration<TransferenciaInterna>
    {
        public void Configure(EntityTypeBuilder<TransferenciaInterna> builder)
        {
            builder.Property(t => t.ChavePixEnvia).HasMaxLength(100).HasColumnName("ChavePixEnvia");
            builder.Property(t => t.ChavePixRecebe).HasMaxLength(100).HasColumnName("ChavePixRecebe");
            builder.Property(t => t.NumeroContaEnvia).HasMaxLength(15);
            builder.Property(t => t.NumeroContaRecebe).HasMaxLength(15);
            builder.Property(t => t.CorrentistaEnviaId).HasPrecision(10).HasColumnName("CorrentistaEnviaId");
            builder.Property(t => t.CorrentistaRecebeId).HasPrecision(10).HasColumnName("CorrentistaRecebeId");
            builder.HasIndex(t => t.CorrentistaRecebeId);
            builder.HasIndex(t => t.CorrentistaEnviaId);  
            
        }
    }
}
