using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Estoque_Agil.Migrations
{
    /// <inheritdoc />
    public partial class AdicionaCampoAtivoEmUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Usuario",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Usuario");
        }
    }
}
