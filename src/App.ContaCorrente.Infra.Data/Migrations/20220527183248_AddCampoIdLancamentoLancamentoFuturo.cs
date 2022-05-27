using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.ContaCorrente.Infra.Data.Migrations
{
    public partial class AddCampoIdLancamentoLancamentoFuturo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Observacao",
                table: "LancamentosFuturos",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdDoLancamento",
                table: "LancamentosFuturos",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdDoLancamento",
                table: "LancamentosFuturos");

            migrationBuilder.AlterColumn<string>(
                name: "Observacao",
                table: "LancamentosFuturos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);
        }
    }
}
