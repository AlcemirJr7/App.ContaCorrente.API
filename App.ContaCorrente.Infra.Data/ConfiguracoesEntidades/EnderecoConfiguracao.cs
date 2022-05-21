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
    public class EnderecoConfiguracao : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Bairro).HasMaxLength(200).IsRequired();
            builder.Property(e => e.Estado).HasMaxLength(200).IsRequired();
            builder.Property(e => e.Cidade).HasMaxLength(200).IsRequired();
            builder.Property(e => e.NomeRua).HasMaxLength(200).IsRequired();
            builder.Property(e => e.Complemento).HasMaxLength(100);
            builder.Property(e => e.Sigla).HasMaxLength(2).IsRequired();
        }
    }
}
