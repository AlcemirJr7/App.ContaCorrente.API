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
    public class SaldoContaCorrenteConfiguracao : IEntityTypeConfiguration<SaldoContaCorrente>
    {
        public void Configure(EntityTypeBuilder<SaldoContaCorrente> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.SaldoConta).HasPrecision(25, 2).IsRequired();
            builder.Property(t => t.LimiteChequeEspecial).HasPrecision(25, 2);
        }
    }
}
