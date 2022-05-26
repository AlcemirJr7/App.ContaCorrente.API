using App.ContaCorrente.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.ContaCorrente.Infra.Data.ConfiguracoesEntidades
{
    public class PagamentoConfiguracao : IEntityTypeConfiguration<Pagamento>
    {
        public void Configure(EntityTypeBuilder<Pagamento> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Valor).HasPrecision(25, 2).IsRequired();
            builder.Property(t => t.NumeroDocumento).HasMaxLength(50).IsRequired();            
            builder.Property(x => x.DataAgendamento).HasColumnType("Date");
            builder.Property(x => x.DataVencimento).HasColumnType("Date");
            builder.Property(x => x.DataGeracao).HasColumnType("Date");            
        }
    }
}
