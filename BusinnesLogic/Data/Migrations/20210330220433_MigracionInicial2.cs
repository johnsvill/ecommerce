using Microsoft.EntityFrameworkCore.Migrations;

namespace BusinnesLogic.Data.Migrations
{
    public partial class MigracionInicial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Categoria",
                table: "Producto",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Marca",
                table: "Producto",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Categoria",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "Marca",
                table: "Producto");
        }
    }
}
