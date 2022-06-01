using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.ContaCorrente.Infra.Data.Migrations
{
    public partial class AddIndexAgenciaContaBancoCorrentista : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Correntista_Agencia_Conta_Banco",
                table: "Correntistas",
                columns: new string[] { "Agencia", "Conta", "BancoId" },
                unique: true
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Correntista_Agencia_Conta_Banco",
                table: "Correntistas");
        }
    }
}
