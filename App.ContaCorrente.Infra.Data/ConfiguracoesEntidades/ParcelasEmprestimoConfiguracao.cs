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
    public class ParcelasEmprestimoConfiguracao : IEntityTypeConfiguration<ParcelasEmprestimo>
    {
        public void Configure(EntityTypeBuilder<ParcelasEmprestimo> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Valor).HasPrecision(25,2).IsRequired();
        }
    }
}
