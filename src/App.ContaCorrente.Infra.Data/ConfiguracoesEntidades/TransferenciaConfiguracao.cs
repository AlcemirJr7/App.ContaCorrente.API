using App.ContaCorrente.Domain.Entidades;
using App.ContaCorrente.Domain.Entidades.Transferencias;
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

        }
    }
}
