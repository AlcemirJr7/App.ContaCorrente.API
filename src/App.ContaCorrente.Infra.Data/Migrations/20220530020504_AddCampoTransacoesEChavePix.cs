using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.ContaCorrente.Infra.Data.Migrations
{
    public partial class AddCampoTransacoesEChavePix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataTransferencia",
                table: "Transferencias",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "ChavePixId",
                table: "Transferencias",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAgendamento",
                table: "Transferencias",
                type: "Date",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCadatro",
                table: "Transferencias",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "NomePessoa",
                table: "Transferencias",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumeroDocumento",
                table: "Transferencias",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoTransferencia",
                table: "Transferencias",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<decimal>(
                name: "SaldoDevedor",
                table: "Emprestimos",
                type: "decimal(25,2)",
                precision: 25,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.CreateTable(
                name: "ChavesPix",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Chave = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoChave = table.Column<int>(type: "int", nullable: false),
                    Situacao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChavesPix", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChavesPix_Chave",
                table: "ChavesPix",
                column: "Chave");

            migrationBuilder.CreateIndex(
                name: "IX_Transferencias_ChavePixId",
                table: "Transferencias",
                column: "ChavePixId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transferencias_ChavesPix_ChavePixId",
                table: "Transferencias",
                column: "ChavePixId",
                principalTable: "ChavesPix",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transferencias_ChavesPix_ChavePixId",
                table: "Transferencias");

            migrationBuilder.DropTable(
                name: "ChavesPix");

            migrationBuilder.DropIndex(
                name: "IX_Transferencias_ChavePixId",
                table: "ChavesPix");

            migrationBuilder.DropIndex(
                name: "IX_ChavesPix_Chave",
                table: "Transferencias");

            migrationBuilder.DropColumn(
                name: "ChavePixId",
                table: "Transferencias");

            migrationBuilder.DropColumn(
                name: "DataAgendamento",
                table: "Transferencias");

            migrationBuilder.DropColumn(
                name: "DataCadatro",
                table: "Transferencias");

            migrationBuilder.DropColumn(
                name: "NomePessoa",
                table: "Transferencias");

            migrationBuilder.DropColumn(
                name: "NumeroDocumento",
                table: "Transferencias");

            migrationBuilder.DropColumn(
                name: "TipoTransferencia",
                table: "Transferencias");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataTransferencia",
                table: "Transferencias",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "SaldoDevedor",
                table: "Emprestimos",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(25,2)",
                oldPrecision: 25,
                oldScale: 2);
        }
    }
}
