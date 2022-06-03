using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.ContaCorrente.Infra.Data.Migrations
{
    public partial class TransferenciaExternaPix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.AddColumn<string>(
                name: "ChavePixEnviaExterno",
                table: "Transferencias",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
           

            migrationBuilder.AddColumn<string>(
                name: "ChavePixRecebeExterno",
                table: "Transferencias",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoChave",
                table: "Transferencias",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {            

            migrationBuilder.DropColumn(
                name: "ChavePixEnviaExterno",
                table: "Transferencias");            

            migrationBuilder.DropColumn(
                name: "ChavePixRecebeExterno",
                table: "Transferencias");                        

            migrationBuilder.DropColumn(
                name: "TipoChave",
                table: "Transferencias");
        }
    }
}
