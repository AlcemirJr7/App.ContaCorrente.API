using App.ContaCorrente.Domain.Entidades;
using App.ContaCorrente.Domain.Entidades.Transferencia;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.ContaCorrente.Infra.Data.ConfiguracoesEntidades
{
    public class TransferenciaConfiguracao : IEntityTypeConfiguration<Transferencia>
    {
        public void Configure(EntityTypeBuilder<Transferencia> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Valor).HasPrecision(25,2).IsRequired();                        
            builder.Property(t => t.DataAgendamento).HasColumnType("Date");
            builder.Property(t => t.ChavePixEnvia).HasMaxLength(100);
            builder.Property(t => t.ChavePixRecebe).HasMaxLength(100);
            builder.Property(t => t.NumeroContaEnvia).HasMaxLength(15);
            builder.Property(t => t.NumeroContaRecebe).HasMaxLength(15);
            builder.Property(t => t.CorrentistaEnviaId).HasPrecision(10);
            builder.Property(t => t.CorrentistaRecebeId).HasPrecision(10);
            builder.HasIndex(t => t.CorrentistaRecebeId);
            builder.HasIndex(t => t.CorrentistaEnviaId);

        }
    }
}
