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
    public class LocalTrabalhoPessoaConfiguracao : IEntityTypeConfiguration<LocalTrabalho>
    {
        public void Configure(EntityTypeBuilder<LocalTrabalho> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Email1).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Email2).HasMaxLength(100);
            builder.Property(x => x.NomeEmpresa).HasMaxLength(300).IsRequired();
            builder.Property(x => x.Salario1).HasPrecision(25,2).IsRequired();
            builder.Property(x => x.Salario2).HasPrecision(25, 2);
            builder.Property(x => x.NumeroTelefone1).HasMaxLength(15).IsRequired();
            builder.Property(x => x.NumeroTelefone2).HasMaxLength(15);
        }
    }
}
