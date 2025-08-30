using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Estoque_Agil.Migrations
{
    /// <inheritdoc />
    public partial class usuarioIdNoProduto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Produto",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Produto_UsuarioId",
                table: "Produto",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Usuario_UsuarioId",
                table: "Produto",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Usuario_UsuarioId",
                table: "Produto");

            migrationBuilder.DropIndex(
                name: "IX_Produto_UsuarioId",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Produto");
        }
    }
}
