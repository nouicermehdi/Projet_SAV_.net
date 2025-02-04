using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrasturcture.Migrations
{
    /// <inheritdoc />
    public partial class InitialCsssxs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NomProduit",
                table: "Reclamations",
                newName: "produit");

            migrationBuilder.RenameColumn(
                name: "NomClient",
                table: "Reclamations",
                newName: "client");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "produit",
                table: "Reclamations",
                newName: "NomProduit");

            migrationBuilder.RenameColumn(
                name: "client",
                table: "Reclamations",
                newName: "NomClient");
        }
    }
}
