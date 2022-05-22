using App.ContaCorrente.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ContaCorrente.Infra.Data.ConfiguracoesEntidades
{
    public class TransferenciaConfiguracao : IEntityTypeConfiguration<Transferencia>
    {
        public void Configure(EntityTypeBuilder<Transferencia> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Valor).HasPrecision(25,2).IsRequired();
            builder.Property(t => t.NumeroConta).HasMaxLength(15);
            builder.Property(t => t.Agencia).HasMaxLength(10);
        }
    }
}
