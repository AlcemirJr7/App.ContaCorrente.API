using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.ContaCorrente.Infra.Data.Migrations
{
    public partial class AddCampoLancamentoFuturo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoLancamento",
                table: "LancamentosFuturos",
                type: "int",
                nullable: false,
                defaultValue: 0);
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoLancamento",
                table: "LancamentosFuturos");
          
                   
        }
    }
}
