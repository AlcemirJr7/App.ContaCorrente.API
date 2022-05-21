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
    public class EmprestimoConfiguracao : IEntityTypeConfiguration<Emprestimo>
    {
        public void Configure(EntityTypeBuilder<Emprestimo> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Juros).HasPrecision(10, 2);
            builder.Property(e => e.Valor).HasPrecision(25, 2);
            builder.Property(e => e.ValorParcela).HasPrecision(25, 2);            

        }
    }
}
