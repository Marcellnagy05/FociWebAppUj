using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FociWebAppUj.Migrations
{
    /// <inheritdoc />
    public partial class sqlitelocal_migration_627 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HazaiCsapat",
                table: "Meccsek",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "HazaiFelido",
                table: "Meccsek",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "VendegCsapat",
                table: "Meccsek",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "VendegFelido",
                table: "Meccsek",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VendegVeg",
                table: "Meccsek",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HazaiCsapat",
                table: "Meccsek");

            migrationBuilder.DropColumn(
                name: "HazaiFelido",
                table: "Meccsek");

            migrationBuilder.DropColumn(
                name: "VendegCsapat",
                table: "Meccsek");

            migrationBuilder.DropColumn(
                name: "VendegFelido",
                table: "Meccsek");

            migrationBuilder.DropColumn(
                name: "VendegVeg",
                table: "Meccsek");
        }
    }
}
