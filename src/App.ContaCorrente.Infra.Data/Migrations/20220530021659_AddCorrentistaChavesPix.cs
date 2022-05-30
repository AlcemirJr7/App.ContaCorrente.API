using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.ContaCorrente.Infra.Data.Migrations
{
    public partial class AddCorrentistaChavesPix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CorrentistaId",
                table: "ChavesPix",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ChavesPix_CorrentistaId",
                table: "ChavesPix",
                column: "CorrentistaId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChavesPix_Correntistas_CorrentistaId",
                table: "ChavesPix",
                column: "CorrentistaId",
                principalTable: "Correntistas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChavesPix_Correntistas_CorrentistaId",
                table: "ChavesPix");

            migrationBuilder.DropIndex(
                name: "IX_ChavesPix_CorrentistaId",
                table: "ChavesPix");

            migrationBuilder.DropColumn(
                name: "CorrentistaId",
                table: "ChavesPix");
        }
    }
}
