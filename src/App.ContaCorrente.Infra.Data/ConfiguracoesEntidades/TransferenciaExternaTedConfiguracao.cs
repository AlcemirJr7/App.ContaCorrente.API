using App.ContaCorrente.Domain.Entidades.Transferencias;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.ContaCorrente.Infra.Data.ConfiguracoesEntidades
{
    public class TransferenciaExternaTedConfiguracao : IEntityTypeConfiguration<TransferenciaExternaTed>
    {
        public void Configure(EntityTypeBuilder<TransferenciaExternaTed> builder)
        {
            builder.Property(t => t.CodigoAgenciaEterno).HasMaxLength(10);
            builder.Property(t => t.NumeroContaExtero).HasMaxLength(15);
            builder.Property(t => t.NomePessoaExtero).HasMaxLength(200);
            builder.Property(t => t.NumeroDocumentoExterno).HasMaxLength(20);
            builder.Property(t => t.CorrentistaEnviaId).HasPrecision(10).HasColumnName("CorrentistaEnviaId");
            
        }
    }
}
