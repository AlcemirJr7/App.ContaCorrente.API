using App.ContaCorrente.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.ContaCorrente.Infra.Data.ConfiguracoesEntidades
{
    public class ParcelasEmprestimoConfiguracao : IEntityTypeConfiguration<ParcelasEmprestimo>
    {
        public void Configure(EntityTypeBuilder<ParcelasEmprestimo> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Valor).HasPrecision(25,2).IsRequired();
            builder.Property(x => x.DataVencimento).HasColumnType("Date");            
        }
    }
}
