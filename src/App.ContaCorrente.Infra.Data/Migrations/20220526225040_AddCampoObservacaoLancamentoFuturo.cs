using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.ContaCorrente.Infra.Data.Migrations
{
    public partial class AddCampoObservacaoLancamentoFuturo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Observacao",
                table: "LancamentosFuturos",
                type: "nvarchar(1000)",
                nullable: true);
           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Observacao",
                table: "LancamentosFuturos");
            
        }
    }
}
