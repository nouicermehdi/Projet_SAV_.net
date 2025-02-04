using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrasturcture.Migrations
{
    /// <inheritdoc />
    public partial class InitialCsssxsss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Statut",
                table: "Interventions",
                newName: "statut");

            migrationBuilder.RenameColumn(
                name: "titreReclamation",
                table: "Interventions",
                newName: "titre");

            migrationBuilder.RenameColumn(
                name: "DateIntervention",
                table: "Interventions",
                newName: "date");

            migrationBuilder.AlterColumn<bool>(
                name: "EstSousGarantie",
                table: "Interventions",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<string>(
                name: "client",
                table: "Interventions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "technicien",
                table: "Interventions",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "client",
                table: "Interventions");

            migrationBuilder.DropColumn(
                name: "technicien",
                table: "Interventions");

            migrationBuilder.RenameColumn(
                name: "statut",
                table: "Interventions",
                newName: "Statut");

            migrationBuilder.RenameColumn(
                name: "titre",
                table: "Interventions",
                newName: "titreReclamation");

            migrationBuilder.RenameColumn(
                name: "date",
                table: "Interventions",
                newName: "DateIntervention");

            migrationBuilder.AlterColumn<bool>(
                name: "EstSousGarantie",
                table: "Interventions",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);
        }
    }
}
