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
    public class BancoConfiguracao : IEntityTypeConfiguration<Banco>
    {
        public void Configure(EntityTypeBuilder<Banco> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Nome).HasMaxLength(200).IsRequired();
            builder.Property(p => p.NomeCompleto).HasMaxLength(500).IsRequired();            
        }
    }
}
