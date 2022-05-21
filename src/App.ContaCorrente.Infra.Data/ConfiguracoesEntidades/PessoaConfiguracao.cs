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
    public class PessoaConfiguracao : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).HasMaxLength(200).IsRequired();
            builder.Property(x => x.NomeEmpresa).HasMaxLength(200);
            builder.Property(x => x.NumeroTelefone1).IsRequired();
            builder.Property(x => x.Email1).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Email2).HasMaxLength(100);

        }
    }
}
