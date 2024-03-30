using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotoXShare.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class DeliveryRiderAndRentalTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeliveryRider",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CNPJ = table.Column<string>(type: "text", nullable: true),
                    CNH = table.Column<string>(type: "text", nullable: true),
                    CNHType = table.Column<int>(type: "integer", nullable: false),
                    CNHImage = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsAdmin = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryRider", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rental",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DeliveryRiderId = table.Column<Guid>(type: "uuid", nullable: false),
                    MotorcycleId = table.Column<Guid>(type: "uuid", nullable: false),
                    Plan = table.Column<int>(type: "integer", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDatePrevision = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rental", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rental_DeliveryRider_DeliveryRiderId",
                        column: x => x.DeliveryRiderId,
                        principalTable: "DeliveryRider",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rental_Motorcycle_MotorcycleId",
                        column: x => x.MotorcycleId,
                        principalTable: "Motorcycle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rental_DeliveryRiderId",
                table: "Rental",
                column: "DeliveryRiderId");

            migrationBuilder.CreateIndex(
                name: "IX_Rental_MotorcycleId",
                table: "Rental",
                column: "MotorcycleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rental");

            migrationBuilder.DropTable(
                name: "DeliveryRider");
        }
    }
}
