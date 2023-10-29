using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cinema.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class deletePricesForScreeninig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReducedTicketPrice",
                table: "Screenings");

            migrationBuilder.DropColumn(
                name: "RegularTicketPrice",
                table: "Screenings");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReducedTicketPrice",
                table: "Screenings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RegularTicketPrice",
                table: "Screenings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
