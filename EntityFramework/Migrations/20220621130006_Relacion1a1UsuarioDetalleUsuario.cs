using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CursoEF6.Migrations
{
    public partial class Relacion1a1UsuarioDetalleUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DetalleUsuarioId",
                table: "DetalleUsuarios",
                newName: "DetalleUsuario_Id");

            migrationBuilder.AddColumn<int>(
                name: "DetalleUsuario_Id",
                table: "usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_DetalleUsuario_Id",
                table: "usuarios",
                column: "DetalleUsuario_Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_usuarios_DetalleUsuarios_DetalleUsuario_Id",
                table: "usuarios",
                column: "DetalleUsuario_Id",
                principalTable: "DetalleUsuarios",
                principalColumn: "DetalleUsuario_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_usuarios_DetalleUsuarios_DetalleUsuario_Id",
                table: "usuarios");

            migrationBuilder.DropIndex(
                name: "IX_usuarios_DetalleUsuario_Id",
                table: "usuarios");

            migrationBuilder.DropColumn(
                name: "DetalleUsuario_Id",
                table: "usuarios");

            migrationBuilder.RenameColumn(
                name: "DetalleUsuario_Id",
                table: "DetalleUsuarios",
                newName: "DetalleUsuarioId");
        }
    }
}
