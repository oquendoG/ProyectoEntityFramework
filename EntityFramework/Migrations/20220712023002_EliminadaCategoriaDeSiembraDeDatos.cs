using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CursoEF6.Migrations
{
    public partial class EliminadaCategoriaDeSiembraDeDatos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "categorias",
                keyColumn: "Categoria_Id",
                keyValue: 22);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "categorias",
                columns: new[] { "Categoria_Id", "Active", "FechaCreacion", "Nombre" },
                values: new object[] { 22, true, new DateTime(2022, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Categoria 9" });
        }
    }
}
