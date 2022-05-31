using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.ContaCorrente.Infra.Data.Migrations
{
    public partial class AlteracaoTransferenciaInterna : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transferencias_Bancos_BancoId",
                table: "Transferencias");

            migrationBuilder.DropForeignKey(
                name: "FK_Transferencias_ChavesPix_ChavePixId",
                table: "Transferencias");

            migrationBuilder.DropForeignKey(
                name: "FK_Transferencias_Correntistas_CorrentistaEnviaId",
                table: "Transferencias");

            migrationBuilder.DropForeignKey(
                name: "FK_Transferencias_Correntistas_CorrentistaRecebeId",
                table: "Transferencias");

            migrationBuilder.DropIndex(
                name: "IX_Transferencias_BancoId",
                table: "Transferencias");

            migrationBuilder.DropIndex(
                name: "IX_Transferencias_ChavePixId",
                table: "Transferencias");

            migrationBuilder.DropIndex(
                name: "IX_Transferencias_CorrentistaEnviaId",
                table: "Transferencias");

            migrationBuilder.DropIndex(
                name: "IX_Transferencias_CorrentistaRecebeId",
                table: "Transferencias");

            migrationBuilder.DropColumn(
                name: "Agencia",
                table: "Transferencias");

            migrationBuilder.DropColumn(
                name: "BancoId",
                table: "Transferencias");

            migrationBuilder.DropColumn(
                name: "ChavePixId",
                table: "Transferencias");

            migrationBuilder.DropColumn(
                name: "NomePessoa",
                table: "Transferencias");

            migrationBuilder.DropColumn(
                name: "NumeroDocumento",
                table: "Transferencias");

            migrationBuilder.RenameColumn(
                name: "NumeroConta",
                table: "Transferencias",
                newName: "NumeroContaRecebe");

            migrationBuilder.AddColumn<string>(
                name: "ChavePixEnvia",
                table: "Transferencias",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ChavePixRecebe",
                table: "Transferencias",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModoTransferencia",
                table: "Transferencias",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NumeroContaEnvia",
                table: "Transferencias",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChavePixEnvia",
                table: "Transferencias");

            migrationBuilder.DropColumn(
                name: "ChavePixRecebe",
                table: "Transferencias");

            migrationBuilder.DropColumn(
                name: "ModoTransferencia",
                table: "Transferencias");

            migrationBuilder.DropColumn(
                name: "NumeroContaEnvia",
                table: "Transferencias");

            migrationBuilder.RenameColumn(
                name: "NumeroContaRecebe",
                table: "Transferencias",
                newName: "NumeroConta");

            migrationBuilder.AddColumn<string>(
                name: "Agencia",
                table: "Transferencias",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BancoId",
                table: "Transferencias",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ChavePixId",
                table: "Transferencias",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Transferencias_BancoId",
                table: "Transferencias",
                column: "BancoId");

            migrationBuilder.CreateIndex(
                name: "IX_Transferencias_ChavePixId",
                table: "Transferencias",
                column: "ChavePixId");

            migrationBuilder.CreateIndex(
                name: "IX_Transferencias_CorrentistaEnviaId",
                table: "Transferencias",
                column: "CorrentistaEnviaId");

            migrationBuilder.CreateIndex(
                name: "IX_Transferencias_CorrentistaRecebeId",
                table: "Transferencias",
                column: "CorrentistaRecebeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transferencias_Bancos_BancoId",
                table: "Transferencias",
                column: "BancoId",
                principalTable: "Bancos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transferencias_ChavesPix_ChavePixId",
                table: "Transferencias",
                column: "ChavePixId",
                principalTable: "ChavesPix",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transferencias_Correntistas_CorrentistaEnviaId",
                table: "Transferencias",
                column: "CorrentistaEnviaId",
                principalTable: "Correntistas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transferencias_Correntistas_CorrentistaRecebeId",
                table: "Transferencias",
                column: "CorrentistaRecebeId",
                principalTable: "Correntistas",
                principalColumn: "Id");
        }
    }
}
