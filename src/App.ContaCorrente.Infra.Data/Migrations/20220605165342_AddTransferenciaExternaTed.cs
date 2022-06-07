using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.ContaCorrente.Infra.Data.Migrations
{
    public partial class AddTransferenciaExternaTed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<string>(
                name: "CodigoAgenciaEterno",
                table: "Transferencias",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CodigoBancoExterno",
                table: "Transferencias",
                type: "int",
                nullable: true);                       

            migrationBuilder.AddColumn<string>(
                name: "NomePessoaExtero",
                table: "Transferencias",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumeroContaExtero",
                table: "Transferencias",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumeroDocumentoExterno",
                table: "Transferencias",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.DropColumn(
                name: "CodigoAgenciaEterno",
                table: "Transferencias");

            migrationBuilder.DropColumn(
                name: "CodigoBancoExterno",
                table: "Transferencias");
                        

            migrationBuilder.DropColumn(
                name: "NomePessoaExtero",
                table: "Transferencias");

            migrationBuilder.DropColumn(
                name: "NumeroContaExtero",
                table: "Transferencias");

            migrationBuilder.DropColumn(
                name: "NumeroDocumentoExterno",
                table: "Transferencias");
            
        }
    }
}
