using App.ContaCorrente.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.ContaCorrente.Infra.Data.ConfiguracoesEntidades
{
    public class LancamentosFuturosConfiguracao : IEntityTypeConfiguration<LancamentoFuturo>
    {
        public void Configure(EntityTypeBuilder<LancamentoFuturo> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Valor).HasPrecision(25, 2).IsRequired();
            builder.Property(x => x.DataParaLancamento).HasColumnType("Date");
        }
    }
}
