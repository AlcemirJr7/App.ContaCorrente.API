using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.ContaCorrente.Infra.Data.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bancos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),                        
                    Nome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NomeCompleto = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bancos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cep = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    NomeRua = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NumeroRua = table.Column<int>(type: "int", nullable: false),
                    Complemento = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Bairro = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Sigla = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Historicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    TipoDebitoCredito = table.Column<int>(type: "int", precision: 1, nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historicos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LocalTrabalhos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeEmpresa = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    NumeroDocumento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cargo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NumeroTelefone1 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    NumeroTelefone2 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Email1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Salario1 = table.Column<decimal>(type: "decimal(25,2)", precision: 25, scale: 2, nullable: false),
                    Salario2 = table.Column<decimal>(type: "decimal(25,2)", precision: 25, scale: 2, nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalTrabalhos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LogSistema",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataLog = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DescricaoLog = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogSistema", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pessoas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NomeEmpresa = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    NumeroDocumento = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TipoPessoa = table.Column<int>(type: "int", nullable: false),
                    NumeroTelefone1 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    NumeroTelefone2 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Email1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "Date", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EnderecoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pessoas_Enderecos_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Enderecos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Correntistas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Agencia = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Conta = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataEncerramento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FlagConta = table.Column<int>(type: "int", nullable: false),
                    PessoaId = table.Column<int>(type: "int", nullable: false),
                    BancoId = table.Column<int>(type: "int", nullable: false),
                    LocalTrabalhoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Correntistas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Correntistas_Bancos_BancoId",
                        column: x => x.BancoId,
                        principalTable: "Bancos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Correntistas_LocalTrabalhos_LocalTrabalhoId",
                        column: x => x.LocalTrabalhoId,
                        principalTable: "LocalTrabalhos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Correntistas_Pessoas_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Emprestimos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<decimal>(type: "decimal(25,2)", precision: 25, scale: 2, nullable: false),
                    TipoFinalidade = table.Column<int>(type: "int", nullable: false),
                    TipoEmprestimo = table.Column<int>(type: "int", nullable: false),
                    QtdParcelas = table.Column<int>(type: "int", nullable: false),
                    ValorParcela = table.Column<decimal>(type: "decimal(25,2)", precision: 25, scale: 2, nullable: false),
                    SaldoDevedor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Juros = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataEfetivacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FlagEstado = table.Column<int>(type: "int", nullable: false),
                    FlagProcesso = table.Column<int>(type: "int", nullable: false),
                    CorrentistaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emprestimos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Emprestimos_Correntistas_CorrentistaId",
                        column: x => x.CorrentistaId,
                        principalTable: "Correntistas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lancamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataLancamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(25,2)", precision: 25, scale: 2, nullable: false),
                    Observacao = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CorrentistaId = table.Column<int>(type: "int", nullable: false),
                    HistoricoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lancamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lancamentos_Correntistas_CorrentistaId",
                        column: x => x.CorrentistaId,
                        principalTable: "Correntistas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lancamentos_Historicos_HistoricoId",
                        column: x => x.HistoricoId,
                        principalTable: "Historicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LancamentosFuturos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<decimal>(type: "decimal(25,2)", precision: 25, scale: 2, nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataParaLancamento = table.Column<DateTime>(type: "Date", nullable: false),
                    FlagLancamento = table.Column<int>(type: "int", nullable: false),
                    DataLancamento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HistoricoId = table.Column<int>(type: "int", nullable: false),
                    CorrentistaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LancamentosFuturos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LancamentosFuturos_Correntistas_CorrentistaId",
                        column: x => x.CorrentistaId,
                        principalTable: "Correntistas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LancamentosFuturos_Historicos_HistoricoId",
                        column: x => x.HistoricoId,
                        principalTable: "Historicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LogContaCorrente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataLog = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DescricaoLog = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorrentistaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogContaCorrente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LogContaCorrente_Correntistas_CorrentistaId",
                        column: x => x.CorrentistaId,
                        principalTable: "Correntistas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pagamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoBarra = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroDocumento = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DataGeracao = table.Column<DateTime>(type: "Date", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(25,2)", precision: 25, scale: 2, nullable: false),
                    DataVencimento = table.Column<DateTime>(type: "Date", nullable: false),
                    DataPagamento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataAgendamento = table.Column<DateTime>(type: "Date", nullable: true),
                    CorrentistaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pagamentos_Correntistas_CorrentistaId",
                        column: x => x.CorrentistaId,
                        principalTable: "Correntistas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SaldoContaCorrente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SaldoConta = table.Column<decimal>(type: "decimal(25,2)", precision: 25, scale: 2, nullable: false),
                    DataUltimaTransacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LimiteChequeEspecial = table.Column<decimal>(type: "decimal(25,2)", precision: 25, scale: 2, nullable: true),
                    CorrentistaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaldoContaCorrente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaldoContaCorrente_Correntistas_CorrentistaId",
                        column: x => x.CorrentistaId,
                        principalTable: "Correntistas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transferencias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroConta = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Agencia = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    DataTransferencia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(25,2)", precision: 25, scale: 2, nullable: false),
                    BancoId = table.Column<int>(type: "int", nullable: true),
                    CorrentistaRecebeId = table.Column<int>(type: "int", nullable: true),
                    CorrentistaEnviaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transferencias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transferencias_Bancos_BancoId",
                        column: x => x.BancoId,
                        principalTable: "Bancos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Transferencias_Correntistas_CorrentistaEnviaId",
                        column: x => x.CorrentistaEnviaId,
                        principalTable: "Correntistas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Transferencias_Correntistas_CorrentistaRecebeId",
                        column: x => x.CorrentistaRecebeId,
                        principalTable: "Correntistas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ParcelasEmprestimos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<decimal>(type: "decimal(25,2)", precision: 25, scale: 2, nullable: false),
                    SeqParcelas = table.Column<int>(type: "int", nullable: false),
                    DataVencimento = table.Column<DateTime>(type: "Date", nullable: false),
                    DataPagamento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmprestimoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParcelasEmprestimos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParcelasEmprestimos_Emprestimos_EmprestimoId",
                        column: x => x.EmprestimoId,
                        principalTable: "Emprestimos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Correntistas_BancoId",
                table: "Correntistas",
                column: "BancoId");

            migrationBuilder.CreateIndex(
                name: "IX_Correntistas_LocalTrabalhoId",
                table: "Correntistas",
                column: "LocalTrabalhoId");

            migrationBuilder.CreateIndex(
                name: "IX_Correntistas_PessoaId",
                table: "Correntistas",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Emprestimos_CorrentistaId",
                table: "Emprestimos",
                column: "CorrentistaId");

            migrationBuilder.CreateIndex(
                name: "IX_Lancamentos_CorrentistaId",
                table: "Lancamentos",
                column: "CorrentistaId");

            migrationBuilder.CreateIndex(
                name: "IX_Lancamentos_HistoricoId",
                table: "Lancamentos",
                column: "HistoricoId");

            migrationBuilder.CreateIndex(
                name: "IX_LancamentosFuturos_CorrentistaId",
                table: "LancamentosFuturos",
                column: "CorrentistaId");

            migrationBuilder.CreateIndex(
                name: "IX_LancamentosFuturos_HistoricoId",
                table: "LancamentosFuturos",
                column: "HistoricoId");

            migrationBuilder.CreateIndex(
                name: "IX_LogContaCorrente_CorrentistaId",
                table: "LogContaCorrente",
                column: "CorrentistaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamentos_CorrentistaId",
                table: "Pagamentos",
                column: "CorrentistaId");

            migrationBuilder.CreateIndex(
                name: "IX_ParcelasEmprestimos_EmprestimoId",
                table: "ParcelasEmprestimos",
                column: "EmprestimoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_EnderecoId",
                table: "Pessoas",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_SaldoContaCorrente_CorrentistaId",
                table: "SaldoContaCorrente",
                column: "CorrentistaId");

            migrationBuilder.CreateIndex(
                name: "IX_Transferencias_BancoId",
                table: "Transferencias",
                column: "BancoId");

            migrationBuilder.CreateIndex(
                name: "IX_Transferencias_CorrentistaEnviaId",
                table: "Transferencias",
                column: "CorrentistaEnviaId");

            migrationBuilder.CreateIndex(
                name: "IX_Transferencias_CorrentistaRecebeId",
                table: "Transferencias",
                column: "CorrentistaRecebeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lancamentos");

            migrationBuilder.DropTable(
                name: "LancamentosFuturos");

            migrationBuilder.DropTable(
                name: "LogContaCorrente");

            migrationBuilder.DropTable(
                name: "LogSistema");

            migrationBuilder.DropTable(
                name: "Pagamentos");

            migrationBuilder.DropTable(
                name: "ParcelasEmprestimos");

            migrationBuilder.DropTable(
                name: "SaldoContaCorrente");

            migrationBuilder.DropTable(
                name: "Transferencias");

            migrationBuilder.DropTable(
                name: "Historicos");

            migrationBuilder.DropTable(
                name: "Emprestimos");

            migrationBuilder.DropTable(
                name: "Correntistas");

            migrationBuilder.DropTable(
                name: "Bancos");

            migrationBuilder.DropTable(
                name: "LocalTrabalhos");

            migrationBuilder.DropTable(
                name: "Pessoas");

            migrationBuilder.DropTable(
                name: "Enderecos");
        }
    }
}
