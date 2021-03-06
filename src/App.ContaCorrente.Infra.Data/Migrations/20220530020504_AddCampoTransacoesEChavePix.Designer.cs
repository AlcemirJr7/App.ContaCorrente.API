// <auto-generated />
using System;
using App.ContaCorrente.Infra.Data.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace App.ContaCorrente.Infra.Data.Migrations
{
    [DbContext(typeof(AppDbContexto))]
    [Migration("20220530020504_AddCampoTransacoesEChavePix")]
    partial class AddCampoTransacoesEChavePix
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("App.ContaCorrente.Domain.Entidades.Banco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("NomeCompleto")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.ToTable("Bancos");
                });

            modelBuilder.Entity("App.ContaCorrente.Domain.Entidades.ChavePix", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Chave")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<int>("Situacao")
                        .HasColumnType("int");

                    b.Property<int>("TipoChave")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ChavesPix");
                });

            modelBuilder.Entity("App.ContaCorrente.Domain.Entidades.Correntista", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Agencia")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("BancoId")
                        .HasColumnType("int");

                    b.Property<string>("Conta")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataEncerramento")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataInicio")
                        .HasColumnType("datetime2");

                    b.Property<int>("FlagConta")
                        .HasColumnType("int");

                    b.Property<int?>("LocalTrabalhoId")
                        .HasColumnType("int");

                    b.Property<int>("PessoaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BancoId");

                    b.HasIndex("LocalTrabalhoId");

                    b.HasIndex("PessoaId");

                    b.ToTable("Correntistas");
                });

            modelBuilder.Entity("App.ContaCorrente.Domain.Entidades.Emprestimo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CorrentistaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataEfetivacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataRejeicao")
                        .HasColumnType("datetime2");

                    b.Property<int>("FlagEstado")
                        .HasColumnType("int");

                    b.Property<int>("FlagProcesso")
                        .HasColumnType("int");

                    b.Property<decimal>("Juros")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("QtdParcelas")
                        .HasColumnType("int");

                    b.Property<decimal>("SaldoDevedor")
                        .HasPrecision(25, 2)
                        .HasColumnType("decimal(25,2)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("TipoEmprestimo")
                        .HasColumnType("int");

                    b.Property<int>("TipoFinalidade")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasPrecision(25, 2)
                        .HasColumnType("decimal(25,2)");

                    b.Property<decimal>("ValorParcela")
                        .HasPrecision(25, 2)
                        .HasColumnType("decimal(25,2)");

                    b.HasKey("Id");

                    b.HasIndex("CorrentistaId");

                    b.ToTable("Emprestimos");
                });

            modelBuilder.Entity("App.ContaCorrente.Domain.Entidades.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Complemento")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("NomeRua")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("NumeroRua")
                        .HasColumnType("int");

                    b.Property<string>("Sigla")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.HasKey("Id");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("App.ContaCorrente.Domain.Entidades.Historico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("TipoDebitoCredito")
                        .HasPrecision(1)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Historicos");
                });

            modelBuilder.Entity("App.ContaCorrente.Domain.Entidades.Lancamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CorrentistaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataLancamento")
                        .HasColumnType("datetime2");

                    b.Property<int>("HistoricoId")
                        .HasColumnType("int");

                    b.Property<string>("Observacao")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<decimal>("Valor")
                        .HasPrecision(25, 2)
                        .HasColumnType("decimal(25,2)");

                    b.HasKey("Id");

                    b.HasIndex("CorrentistaId");

                    b.HasIndex("HistoricoId");

                    b.ToTable("Lancamentos");
                });

            modelBuilder.Entity("App.ContaCorrente.Domain.Entidades.LancamentoFuturo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CorrentistaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataLancamento")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataParaLancamento")
                        .HasColumnType("Date");

                    b.Property<int>("FlagLancamento")
                        .HasColumnType("int");

                    b.Property<int>("HistoricoId")
                        .HasColumnType("int");

                    b.Property<int?>("IdDoLancamento")
                        .HasColumnType("int");

                    b.Property<string>("Observacao")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("Situacao")
                        .HasColumnType("int");

                    b.Property<int>("TipoLancamento")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasPrecision(25, 2)
                        .HasColumnType("decimal(25,2)");

                    b.HasKey("Id");

                    b.HasIndex("CorrentistaId");

                    b.HasIndex("HistoricoId");

                    b.ToTable("LancamentosFuturos");
                });

            modelBuilder.Entity("App.ContaCorrente.Domain.Entidades.LocalTrabalho", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Cargo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email1")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Email2")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NomeEmpresa")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("NumeroDocumento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroTelefone1")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("NumeroTelefone2")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<decimal>("Salario1")
                        .HasPrecision(25, 2)
                        .HasColumnType("decimal(25,2)");

                    b.Property<decimal?>("Salario2")
                        .HasPrecision(25, 2)
                        .HasColumnType("decimal(25,2)");

                    b.HasKey("Id");

                    b.ToTable("LocalTrabalhos");
                });

            modelBuilder.Entity("App.ContaCorrente.Domain.Entidades.Logs.LogContaCorrente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CorrentistaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataLog")
                        .HasColumnType("datetime2");

                    b.Property<string>("DescricaoLog")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CorrentistaId");

                    b.ToTable("LogContaCorrente");
                });

            modelBuilder.Entity("App.ContaCorrente.Domain.Entidades.Logs.LogSistema", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DataLog")
                        .HasColumnType("datetime2");

                    b.Property<string>("DescricaoLog")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LogSistema");
                });

            modelBuilder.Entity("App.ContaCorrente.Domain.Entidades.Pagamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CodigoBarra")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CorrentistaId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DataAgendamento")
                        .HasColumnType("Date");

                    b.Property<DateTime>("DataGeracao")
                        .HasColumnType("Date");

                    b.Property<DateTime?>("DataPagamento")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataVencimento")
                        .HasColumnType("Date");

                    b.Property<string>("NumeroDocumento")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Valor")
                        .HasPrecision(25, 2)
                        .HasColumnType("decimal(25,2)");

                    b.HasKey("Id");

                    b.HasIndex("CorrentistaId");

                    b.ToTable("Pagamentos");
                });

            modelBuilder.Entity("App.ContaCorrente.Domain.Entidades.ParcelasEmprestimo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("DataPagamento")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataVencimento")
                        .HasColumnType("Date");

                    b.Property<int>("EmprestimoId")
                        .HasColumnType("int");

                    b.Property<int>("SeqParcelas")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasPrecision(25, 2)
                        .HasColumnType("decimal(25,2)");

                    b.HasKey("Id");

                    b.HasIndex("EmprestimoId");

                    b.ToTable("ParcelasEmprestimos");
                });

            modelBuilder.Entity("App.ContaCorrente.Domain.Entidades.Pessoa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("Date");

                    b.Property<string>("Email1")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Email2")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("NomeEmpresa")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("NumeroDocumento")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("NumeroTelefone1")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("NumeroTelefone2")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int>("TipoPessoa")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId");

                    b.ToTable("Pessoas");
                });

            modelBuilder.Entity("App.ContaCorrente.Domain.Entidades.SaldoContaCorrente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CorrentistaId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DataUltimaTransacao")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("LimiteChequeEspecial")
                        .HasPrecision(25, 2)
                        .HasColumnType("decimal(25,2)");

                    b.Property<decimal>("SaldoConta")
                        .HasPrecision(25, 2)
                        .HasColumnType("decimal(25,2)");

                    b.HasKey("Id");

                    b.HasIndex("CorrentistaId");

                    b.ToTable("SaldoContaCorrente");
                });

            modelBuilder.Entity("App.ContaCorrente.Domain.Entidades.Transferencia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Agencia")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int?>("BancoId")
                        .HasColumnType("int");

                    b.Property<int?>("ChavePixId")
                        .HasColumnType("int");

                    b.Property<int?>("CorrentistaEnviaId")
                        .HasColumnType("int");

                    b.Property<int?>("CorrentistaRecebeId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DataAgendamento")
                        .HasColumnType("Date");

                    b.Property<DateTime>("DataCadatro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataTransferencia")
                        .HasColumnType("datetime2");

                    b.Property<string>("NomePessoa")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("NumeroConta")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("NumeroDocumento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoTransferencia")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasPrecision(25, 2)
                        .HasColumnType("decimal(25,2)");

                    b.HasKey("Id");

                    b.HasIndex("BancoId");

                    b.HasIndex("ChavePixId");

                    b.HasIndex("CorrentistaEnviaId");

                    b.HasIndex("CorrentistaRecebeId");

                    b.ToTable("Transferencias");
                });

            modelBuilder.Entity("App.ContaCorrente.Domain.Entidades.Correntista", b =>
                {
                    b.HasOne("App.ContaCorrente.Domain.Entidades.Banco", "Banco")
                        .WithMany()
                        .HasForeignKey("BancoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.ContaCorrente.Domain.Entidades.LocalTrabalho", "LocalTrabalho")
                        .WithMany()
                        .HasForeignKey("LocalTrabalhoId");

                    b.HasOne("App.ContaCorrente.Domain.Entidades.Pessoa", "Pessoa")
                        .WithMany()
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Banco");

                    b.Navigation("LocalTrabalho");

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("App.ContaCorrente.Domain.Entidades.Emprestimo", b =>
                {
                    b.HasOne("App.ContaCorrente.Domain.Entidades.Correntista", "Correntista")
                        .WithMany()
                        .HasForeignKey("CorrentistaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Correntista");
                });

            modelBuilder.Entity("App.ContaCorrente.Domain.Entidades.Lancamento", b =>
                {
                    b.HasOne("App.ContaCorrente.Domain.Entidades.Correntista", "Correntista")
                        .WithMany()
                        .HasForeignKey("CorrentistaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.ContaCorrente.Domain.Entidades.Historico", "Historico")
                        .WithMany()
                        .HasForeignKey("HistoricoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Correntista");

                    b.Navigation("Historico");
                });

            modelBuilder.Entity("App.ContaCorrente.Domain.Entidades.LancamentoFuturo", b =>
                {
                    b.HasOne("App.ContaCorrente.Domain.Entidades.Correntista", "Correntista")
                        .WithMany()
                        .HasForeignKey("CorrentistaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.ContaCorrente.Domain.Entidades.Historico", "Historico")
                        .WithMany()
                        .HasForeignKey("HistoricoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Correntista");

                    b.Navigation("Historico");
                });

            modelBuilder.Entity("App.ContaCorrente.Domain.Entidades.Logs.LogContaCorrente", b =>
                {
                    b.HasOne("App.ContaCorrente.Domain.Entidades.Correntista", "Correntista")
                        .WithMany()
                        .HasForeignKey("CorrentistaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Correntista");
                });

            modelBuilder.Entity("App.ContaCorrente.Domain.Entidades.Pagamento", b =>
                {
                    b.HasOne("App.ContaCorrente.Domain.Entidades.Correntista", "Correntista")
                        .WithMany()
                        .HasForeignKey("CorrentistaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Correntista");
                });

            modelBuilder.Entity("App.ContaCorrente.Domain.Entidades.ParcelasEmprestimo", b =>
                {
                    b.HasOne("App.ContaCorrente.Domain.Entidades.Emprestimo", "Emprestimo")
                        .WithMany()
                        .HasForeignKey("EmprestimoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Emprestimo");
                });

            modelBuilder.Entity("App.ContaCorrente.Domain.Entidades.Pessoa", b =>
                {
                    b.HasOne("App.ContaCorrente.Domain.Entidades.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("App.ContaCorrente.Domain.Entidades.SaldoContaCorrente", b =>
                {
                    b.HasOne("App.ContaCorrente.Domain.Entidades.Correntista", "Correntista")
                        .WithMany()
                        .HasForeignKey("CorrentistaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Correntista");
                });

            modelBuilder.Entity("App.ContaCorrente.Domain.Entidades.Transferencia", b =>
                {
                    b.HasOne("App.ContaCorrente.Domain.Entidades.Banco", "Banco")
                        .WithMany()
                        .HasForeignKey("BancoId");

                    b.HasOne("App.ContaCorrente.Domain.Entidades.ChavePix", "ChavePix")
                        .WithMany()
                        .HasForeignKey("ChavePixId");

                    b.HasOne("App.ContaCorrente.Domain.Entidades.Correntista", "CorrentistaEnvia")
                        .WithMany()
                        .HasForeignKey("CorrentistaEnviaId");

                    b.HasOne("App.ContaCorrente.Domain.Entidades.Correntista", "CorrentistaRecebe")
                        .WithMany()
                        .HasForeignKey("CorrentistaRecebeId");

                    b.Navigation("Banco");

                    b.Navigation("ChavePix");

                    b.Navigation("CorrentistaEnvia");

                    b.Navigation("CorrentistaRecebe");
                });
#pragma warning restore 612, 618
        }
    }
}
