using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMainConnectionBeetwenCarAndTrain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carriages_Trains_TrainId",
                table: "Carriages");

            migrationBuilder.DropIndex(
                name: "IX_Carriages_TrainId",
                table: "Carriages");

            migrationBuilder.DropColumn(
                name: "TrainId",
                table: "Carriages");

            migrationBuilder.AddColumn<int>(
                name: "CarriageId",
                table: "Trains",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Trains_CarriageId",
                table: "Trains",
                column: "CarriageId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Trains_Carriages_CarriageId",
                table: "Trains",
                column: "CarriageId",
                principalTable: "Carriages",
                principalColumn: "carriage_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trains_Carriages_CarriageId",
                table: "Trains");

            migrationBuilder.DropIndex(
                name: "IX_Trains_CarriageId",
                table: "Trains");

            migrationBuilder.DropColumn(
                name: "CarriageId",
                table: "Trains");

            migrationBuilder.AddColumn<int>(
                name: "TrainId",
                table: "Carriages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Carriages_TrainId",
                table: "Carriages",
                column: "TrainId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Carriages_Trains_TrainId",
                table: "Carriages",
                column: "TrainId",
                principalTable: "Trains",
                principalColumn: "train_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
