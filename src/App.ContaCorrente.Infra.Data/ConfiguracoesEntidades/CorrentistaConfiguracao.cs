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
    public class CorrentistaConfiguracao : IEntityTypeConfiguration<Correntista>
    {
        public void Configure(EntityTypeBuilder<Correntista> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Agencia).HasMaxLength(10);
            builder.Property(t => t.Conta).HasMaxLength(15);
        }
    }
}
