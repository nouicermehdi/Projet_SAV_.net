using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrasturcture.Migrations
{
    /// <inheritdoc />
    public partial class InitialC : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NomClient",
                table: "Reclamations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NomProduit",
                table: "Reclamations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "titreReclamation",
                table: "Interventions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomClient",
                table: "Reclamations");

            migrationBuilder.DropColumn(
                name: "NomProduit",
                table: "Reclamations");

            migrationBuilder.DropColumn(
                name: "titreReclamation",
                table: "Interventions");
        }
    }
}
