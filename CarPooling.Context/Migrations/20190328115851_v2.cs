using Microsoft.EntityFrameworkCore.Migrations;

namespace CarPooling.Context.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Rides_DestinationCityId",
                table: "Rides");

            migrationBuilder.DropIndex(
                name: "IX_Rides_SourceCityId",
                table: "Rides");

            migrationBuilder.AlterColumn<int>(
                name: "SourceCityId",
                table: "Rides",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "DestinationCityId",
                table: "Rides",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Rides_DestinationCityId",
                table: "Rides",
                column: "DestinationCityId");

            migrationBuilder.CreateIndex(
                name: "IX_Rides_SourceCityId",
                table: "Rides",
                column: "SourceCityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Rides_DestinationCityId",
                table: "Rides");

            migrationBuilder.DropIndex(
                name: "IX_Rides_SourceCityId",
                table: "Rides");

            migrationBuilder.AlterColumn<int>(
                name: "SourceCityId",
                table: "Rides",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DestinationCityId",
                table: "Rides",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rides_DestinationCityId",
                table: "Rides",
                column: "DestinationCityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rides_SourceCityId",
                table: "Rides",
                column: "SourceCityId",
                unique: true);
        }
    }
}
