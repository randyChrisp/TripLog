using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TripLog.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    TripsLogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dest = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Acommodation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AcommPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AcommEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToDo1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToDo2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToDo3 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.TripsLogId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trips");
        }
    }
}
