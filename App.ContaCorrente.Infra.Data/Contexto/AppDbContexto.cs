﻿
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
        public DbSet<Correntista> Correntistas { get; set; }
        public DbSet<Emprestimo> Emprestimos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Lancamentos> Lancamentos { get; set; }
        public DbSet<LancamentosFuturos> LancamentosFuturos { get; set; }
        public DbSet<LocalTrabalhoPessoa> LocalTrabalhoPessoas { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }
        public DbSet<ParcelasEmprestimo> ParcelasEmprestimos { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<SaldoContaCorrente> SaldoContaCorrente { get; set; }
        public DbSet<Transferencia> Transferencias { get; set; }
        public DbSet<LogContaCorrente> LogContaCorrente { get; set; }
        public DbSet<LogSistema> LogSistema { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(AppDbContexto).Assembly);

        }
    }
}