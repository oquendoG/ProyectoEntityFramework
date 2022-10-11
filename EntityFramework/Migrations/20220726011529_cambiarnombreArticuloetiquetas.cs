using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CursoEF6.Migrations
{
    public partial class cambiarnombreArticuloetiquetas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticuloEtiqueta_Articulos_Articulo_Id",
                table: "ArticuloEtiqueta");

            migrationBuilder.DropForeignKey(
                name: "FK_ArticuloEtiqueta_Etiquetas_EtiquetaId",
                table: "ArticuloEtiqueta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArticuloEtiqueta",
                table: "ArticuloEtiqueta");

            migrationBuilder.RenameTable(
                name: "ArticuloEtiqueta",
                newName: "ArticuloEtiquetas");

            migrationBuilder.RenameIndex(
                name: "IX_ArticuloEtiqueta_Articulo_Id",
                table: "ArticuloEtiquetas",
                newName: "IX_ArticuloEtiquetas_Articulo_Id");

            migrationBuilder.AlterColumn<string>(
                name: "NombreUsuario",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Direccion",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Titulo",
                table: "Etiquetas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Mascota",
                table: "DetalleUsuarios",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Deporte",
                table: "DetalleUsuarios",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArticuloEtiquetas",
                table: "ArticuloEtiquetas",
                columns: new[] { "EtiquetaId", "Articulo_Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_ArticuloEtiquetas_Articulos_Articulo_Id",
                table: "ArticuloEtiquetas",
                column: "Articulo_Id",
                principalTable: "Articulos",
                principalColumn: "Articulo_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArticuloEtiquetas_Etiquetas_EtiquetaId",
                table: "ArticuloEtiquetas",
                column: "EtiquetaId",
                principalTable: "Etiquetas",
                principalColumn: "EtiquetaId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticuloEtiquetas_Articulos_Articulo_Id",
                table: "ArticuloEtiquetas");

            migrationBuilder.DropForeignKey(
                name: "FK_ArticuloEtiquetas_Etiquetas_EtiquetaId",
                table: "ArticuloEtiquetas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArticuloEtiquetas",
                table: "ArticuloEtiquetas");

            migrationBuilder.RenameTable(
                name: "ArticuloEtiquetas",
                newName: "ArticuloEtiqueta");

            migrationBuilder.RenameIndex(
                name: "IX_ArticuloEtiquetas_Articulo_Id",
                table: "ArticuloEtiqueta",
                newName: "IX_ArticuloEtiqueta_Articulo_Id");

            migrationBuilder.AlterColumn<string>(
                name: "NombreUsuario",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Direccion",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Titulo",
                table: "Etiquetas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Mascota",
                table: "DetalleUsuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Deporte",
                table: "DetalleUsuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArticuloEtiqueta",
                table: "ArticuloEtiqueta",
                columns: new[] { "EtiquetaId", "Articulo_Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_ArticuloEtiqueta_Articulos_Articulo_Id",
                table: "ArticuloEtiqueta",
                column: "Articulo_Id",
                principalTable: "Articulos",
                principalColumn: "Articulo_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArticuloEtiqueta_Etiquetas_EtiquetaId",
                table: "ArticuloEtiqueta",
                column: "EtiquetaId",
                principalTable: "Etiquetas",
                principalColumn: "EtiquetaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
