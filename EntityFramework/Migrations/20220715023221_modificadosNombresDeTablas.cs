using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CursoEF6.Migrations
{
    public partial class modificadosNombresDeTablas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticuloEtiqueta_Tbl_Articulo_Articulo_Id",
                table: "ArticuloEtiqueta");

            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Articulo_categorias_Categoria_Id",
                table: "Tbl_Articulo");

            migrationBuilder.DropForeignKey(
                name: "FK_usuarios_DetalleUsuarios_DetalleUsuario_Id",
                table: "usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_usuarios",
                table: "usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_categorias",
                table: "categorias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tbl_Articulo",
                table: "Tbl_Articulo");

            migrationBuilder.RenameTable(
                name: "usuarios",
                newName: "Usuarios");

            migrationBuilder.RenameTable(
                name: "categorias",
                newName: "Categorias");

            migrationBuilder.RenameTable(
                name: "Tbl_Articulo",
                newName: "Articulos");

            migrationBuilder.RenameIndex(
                name: "IX_usuarios_DetalleUsuario_Id",
                table: "Usuarios",
                newName: "IX_Usuarios_DetalleUsuario_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Tbl_Articulo_Categoria_Id",
                table: "Articulos",
                newName: "IX_Articulos_Categoria_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categorias",
                table: "Categorias",
                column: "Categoria_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Articulos",
                table: "Articulos",
                column: "Articulo_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticuloEtiqueta_Articulos_Articulo_Id",
                table: "ArticuloEtiqueta",
                column: "Articulo_Id",
                principalTable: "Articulos",
                principalColumn: "Articulo_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Articulos_Categorias_Categoria_Id",
                table: "Articulos",
                column: "Categoria_Id",
                principalTable: "Categorias",
                principalColumn: "Categoria_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_DetalleUsuarios_DetalleUsuario_Id",
                table: "Usuarios",
                column: "DetalleUsuario_Id",
                principalTable: "DetalleUsuarios",
                principalColumn: "DetalleUsuario_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticuloEtiqueta_Articulos_Articulo_Id",
                table: "ArticuloEtiqueta");

            migrationBuilder.DropForeignKey(
                name: "FK_Articulos_Categorias_Categoria_Id",
                table: "Articulos");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_DetalleUsuarios_DetalleUsuario_Id",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categorias",
                table: "Categorias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Articulos",
                table: "Articulos");

            migrationBuilder.RenameTable(
                name: "Usuarios",
                newName: "usuarios");

            migrationBuilder.RenameTable(
                name: "Categorias",
                newName: "categorias");

            migrationBuilder.RenameTable(
                name: "Articulos",
                newName: "Tbl_Articulo");

            migrationBuilder.RenameIndex(
                name: "IX_Usuarios_DetalleUsuario_Id",
                table: "usuarios",
                newName: "IX_usuarios_DetalleUsuario_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Articulos_Categoria_Id",
                table: "Tbl_Articulo",
                newName: "IX_Tbl_Articulo_Categoria_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_usuarios",
                table: "usuarios",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_categorias",
                table: "categorias",
                column: "Categoria_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tbl_Articulo",
                table: "Tbl_Articulo",
                column: "Articulo_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticuloEtiqueta_Tbl_Articulo_Articulo_Id",
                table: "ArticuloEtiqueta",
                column: "Articulo_Id",
                principalTable: "Tbl_Articulo",
                principalColumn: "Articulo_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Articulo_categorias_Categoria_Id",
                table: "Tbl_Articulo",
                column: "Categoria_Id",
                principalTable: "categorias",
                principalColumn: "Categoria_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_usuarios_DetalleUsuarios_DetalleUsuario_Id",
                table: "usuarios",
                column: "DetalleUsuario_Id",
                principalTable: "DetalleUsuarios",
                principalColumn: "DetalleUsuario_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
