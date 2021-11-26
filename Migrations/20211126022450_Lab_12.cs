using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TripLog.Migrations
{
    public partial class Lab_12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accommodations",
                columns: table => new
                {
                    AccommodationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accommodations", x => x.AccommodationId);
                });

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    ActivityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ToDo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.ActivityId);
                });

            migrationBuilder.CreateTable(
                name: "Destinations",
                columns: table => new
                {
                    DestinationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dest = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destinations", x => x.DestinationId);
                });

            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    TripsLogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DestinationId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccommodationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.TripsLogId);
                    table.ForeignKey(
                        name: "FK_Trips_Accommodations_AccommodationId",
                        column: x => x.AccommodationId,
                        principalTable: "Accommodations",
                        principalColumn: "AccommodationId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Trips_Destinations_DestinationId",
                        column: x => x.DestinationId,
                        principalTable: "Destinations",
                        principalColumn: "DestinationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TripActivities",
                columns: table => new
                {
                    TripsLogId = table.Column<int>(type: "int", nullable: false),
                    ActivityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripActivities", x => new { x.TripsLogId, x.ActivityId });
                    table.ForeignKey(
                        name: "FK_TripActivities_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "ActivityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TripActivities_Trips_TripsLogId",
                        column: x => x.TripsLogId,
                        principalTable: "Trips",
                        principalColumn: "TripsLogId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TripActivities_ActivityId",
                table: "TripActivities",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_AccommodationId",
                table: "Trips",
                column: "AccommodationId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_DestinationId",
                table: "Trips",
                column: "DestinationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TripActivities");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "Trips");

            migrationBuilder.DropTable(
                name: "Accommodations");

            migrationBuilder.DropTable(
                name: "Destinations");
        }
    }
}
