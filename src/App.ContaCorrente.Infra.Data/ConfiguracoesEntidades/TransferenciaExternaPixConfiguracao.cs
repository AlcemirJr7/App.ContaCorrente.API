using App.ContaCorrente.Domain.Entidades.Transferencias;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.ContaCorrente.Infra.Data.ConfiguracoesEntidades
{
    public class TransferenciaExternaPixConfiguracao : IEntityTypeConfiguration<TransferenciaExternaPix>
    {
        public void Configure(EntityTypeBuilder<TransferenciaExternaPix> builder)
        {
            builder.Property(t => t.ChavePixEnviaExterno).HasMaxLength(100);
            builder.Property(t => t.ChavePixRecebeExterno).HasMaxLength(100);
                            
        }
    }
}
