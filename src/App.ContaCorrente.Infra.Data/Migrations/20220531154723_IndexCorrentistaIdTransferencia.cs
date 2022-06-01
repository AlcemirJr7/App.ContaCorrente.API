using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.ContaCorrente.Infra.Data.Migrations
{
    public partial class IndexCorrentistaIdTransferencia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
            migrationBuilder.DropIndex(
                name: "IX_Transferencias_CorrentistaEnviaId",
                table: "Transferencias");

            migrationBuilder.DropIndex(
                name: "IX_Transferencias_CorrentistaRecebeId",
                table: "Transferencias");
        }
    }
}
