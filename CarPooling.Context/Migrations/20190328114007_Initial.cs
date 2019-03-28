using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarPooling.Context.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Model = table.Column<string>(maxLength: 32, nullable: true),
                    Color = table.Column<string>(maxLength: 32, nullable: true),
                    Seats = table.Column<int>(nullable: true),
                    CarNumbers = table.Column<string>(maxLength: 32, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CityName = table.Column<string>(maxLength: 64, nullable: false),
                    State = table.Column<string>(maxLength: 64, nullable: false),
                    Country = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(maxLength: 32, nullable: false),
                    Email = table.Column<string>(maxLength: 128, nullable: false),
                    FirstName = table.Column<string>(maxLength: 32, nullable: false),
                    LastName = table.Column<string>(maxLength: 32, nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Date_created = table.Column<DateTime>(nullable: false),
                    Phone = table.Column<string>(maxLength: 32, nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rides",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CarId = table.Column<int>(nullable: true),
                    TravelStartDateTime = table.Column<DateTime>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    SourceCityId = table.Column<int>(nullable: false),
                    DestinationCityId = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rides", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rides_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rides_Cities_DestinationCityId",
                        column: x => x.DestinationCityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rides_Cities_SourceCityId",
                        column: x => x.SourceCityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MembersCars",
                columns: table => new
                {
                    CarId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembersCars", x => new { x.CarId, x.UserId });
                    table.ForeignKey(
                        name: "FK_MembersCars_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MembersCars_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Preferences",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    Talkative = table.Column<int>(nullable: true),
                    Allow_smoke = table.Column<bool>(nullable: true),
                    Allow_pet = table.Column<bool>(nullable: true),
                    Volume = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preferences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Preferences_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnrouteCity",
                columns: table => new
                {
                    RideId = table.Column<int>(nullable: false),
                    CityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnrouteCity", x => new { x.CityId, x.RideId });
                    table.ForeignKey(
                        name: "FK_EnrouteCity_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnrouteCity_Rides_RideId",
                        column: x => x.RideId,
                        principalTable: "Rides",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Status = table.Column<bool>(nullable: true),
                    RideId = table.Column<int>(nullable: false),
                    EnrouteCityId = table.Column<int>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    RequesterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requests_Cities_EnrouteCityId",
                        column: x => x.EnrouteCityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requests_Users_RequesterId",
                        column: x => x.RequesterId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requests_Rides_RideId",
                        column: x => x.RideId,
                        principalTable: "Rides",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EnrouteCity_RideId",
                table: "EnrouteCity",
                column: "RideId");

            migrationBuilder.CreateIndex(
                name: "IX_MembersCars_UserId",
                table: "MembersCars",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Preferences_UserId",
                table: "Preferences",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Requests_EnrouteCityId",
                table: "Requests",
                column: "EnrouteCityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Requests_RequesterId",
                table: "Requests",
                column: "RequesterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Requests_RideId",
                table: "Requests",
                column: "RideId");

            migrationBuilder.CreateIndex(
                name: "IX_Rides_CarId",
                table: "Rides",
                column: "CarId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnrouteCity");

            migrationBuilder.DropTable(
                name: "MembersCars");

            migrationBuilder.DropTable(
                name: "Preferences");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Rides");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
