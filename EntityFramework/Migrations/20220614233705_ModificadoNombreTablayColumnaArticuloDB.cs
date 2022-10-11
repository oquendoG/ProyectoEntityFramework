using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CursoEF6.Migrations
{
    public partial class ModificadoNombreTablayColumnaArticuloDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_articulos",
                table: "articulos");

            migrationBuilder.RenameTable(
                name: "articulos",
                newName: "Tbl_Articulo");

            migrationBuilder.RenameColumn(
                name: "TituloArticulo",
                table: "Tbl_Articulo",
                newName: "titulo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tbl_Articulo",
                table: "Tbl_Articulo",
                column: "ArticuloId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Tbl_Articulo",
                table: "Tbl_Articulo");

            migrationBuilder.RenameTable(
                name: "Tbl_Articulo",
                newName: "articulos");

            migrationBuilder.RenameColumn(
                name: "titulo",
                table: "articulos",
                newName: "TituloArticulo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_articulos",
                table: "articulos",
                column: "ArticuloId");
        }
    }
}
