using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CursoEF6.Migrations
{
    public partial class DetalleIdComoNuloYEliminadaCalificacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_DetalleUsuarios_DetalleUsuario_Id",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_DetalleUsuario_Id",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Calificaion",
                table: "Usuarios");

            migrationBuilder.AlterColumn<int>(
                name: "DetalleUsuario_Id",
                table: "Usuarios",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_DetalleUsuario_Id",
                table: "Usuarios",
                column: "DetalleUsuario_Id",
                unique: true,
                filter: "[DetalleUsuario_Id] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_DetalleUsuarios_DetalleUsuario_Id",
                table: "Usuarios",
                column: "DetalleUsuario_Id",
                principalTable: "DetalleUsuarios",
                principalColumn: "DetalleUsuario_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_DetalleUsuarios_DetalleUsuario_Id",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_DetalleUsuario_Id",
                table: "Usuarios");

            migrationBuilder.AlterColumn<int>(
                name: "DetalleUsuario_Id",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Calificaion",
                table: "Usuarios",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_DetalleUsuario_Id",
                table: "Usuarios",
                column: "DetalleUsuario_Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_DetalleUsuarios_DetalleUsuario_Id",
                table: "Usuarios",
                column: "DetalleUsuario_Id",
                principalTable: "DetalleUsuarios",
                principalColumn: "DetalleUsuario_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
