using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddConnectWithStation2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RouteStops_StationId",
                table: "RouteStops");

            migrationBuilder.CreateIndex(
                name: "IX_RouteStops_StationId",
                table: "RouteStops",
                column: "StationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RouteStops_StationId",
                table: "RouteStops");

            migrationBuilder.CreateIndex(
                name: "IX_RouteStops_StationId",
                table: "RouteStops",
                column: "StationId",
                unique: true);
        }
    }
}
