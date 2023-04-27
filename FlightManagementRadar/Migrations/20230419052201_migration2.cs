using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightManagementRadar.Migrations
{
    public partial class migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flight_Datas",
                columns: table => new
                {
                    Flight_ID = table.Column<int>(type: "int", nullable: false),
                    Flight_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Boarding_Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fare = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flight_Datas", x => x.Flight_ID);
                });

            migrationBuilder.CreateTable(
                name: "CheckIn_Details",
                columns: table => new
                {
                    Boarding_Id = table.Column<int>(type: "int", nullable: false),
                    FlightId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phonenum = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    user_detailsUserName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    flight_dataFlight_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckIn_Details", x => x.Boarding_Id);
                    table.ForeignKey(
                        name: "FK_CheckIn_Details_Flight_Datas_flight_dataFlight_ID",
                        column: x => x.flight_dataFlight_ID,
                        principalTable: "Flight_Datas",
                        principalColumn: "Flight_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CheckIn_Details_Users_user_detailsUserName",
                        column: x => x.user_detailsUserName,
                        principalTable: "Users",
                        principalColumn: "UserName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CheckIn_Details_flight_dataFlight_ID",
                table: "CheckIn_Details",
                column: "flight_dataFlight_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CheckIn_Details_user_detailsUserName",
                table: "CheckIn_Details",
                column: "user_detailsUserName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CheckIn_Details");

            migrationBuilder.DropTable(
                name: "Flight_Datas");
        }
    }
}
