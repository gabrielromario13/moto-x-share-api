using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotoXShare.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangedActiveToMotorcycle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Rental");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Motorcycle",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Motorcycle");
        }
    }
}
