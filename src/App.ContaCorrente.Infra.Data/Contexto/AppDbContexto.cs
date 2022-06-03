using App.ContaCorrente.Domain.Entidades.Transferencias;
using App.ContaCorrente.Domain.Entidades;
using App.ContaCorrente.Domain.Entidades.Logs;
using Microsoft.EntityFrameworkCore;

namespace App.ContaCorrente.Infra.Data.Contexto
{
    public class AppDbContexto : DbContext
    {
        public AppDbContexto(DbContextOptions<AppDbContexto> options) : base(options)
        {
            
        }

        public DbSet<Banco> Bancos{ get; set; }
        public DbSet<Historico> Historicos { get; set; }
        public DbSet<Correntista> Correntistas { get; set; }
        public DbSet<Emprestimo> Emprestimos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Lancamento> Lancamentos { get; set; }
        public DbSet<LancamentoFuturo> LancamentosFuturos { get; set; }
        public DbSet<LocalTrabalho> LocalTrabalhos { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }
        public DbSet<ParcelasEmprestimo> ParcelasEmprestimos { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<SaldoContaCorrente> SaldoContaCorrente { get; set; }
        public DbSet<Transferencia> Transferencias { get; set; }
        public DbSet<LogContaCorrente> LogContaCorrente { get; set; }
        public DbSet<LogSistema> LogSistema { get; set; }

        public DbSet<ChavePix> ChavesPix { get; set; }

        


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Ignore<TransferenciaInterna>();
            builder.Ignore<TransferenciaExternaPix>();           
            base.OnModelCreating(builder);            
            builder.ApplyConfigurationsFromAssembly(typeof(AppDbContexto).Assembly);

        }
    }
}
