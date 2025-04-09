using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class NomeDaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdServico",
                table: "SessionService",
                newName: "IdSession");

            migrationBuilder.RenameColumn(
                name: "IdConsulta",
                table: "SessionService",
                newName: "IdService");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "User",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "IdSession",
                table: "SessionService",
                newName: "IdServico");

            migrationBuilder.RenameColumn(
                name: "IdService",
                table: "SessionService",
                newName: "IdConsulta");
        }
    }
}
