using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightManagementRadar.Migrations
{
    public partial class namechange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckIn_Details_Flight_Datas_flight_dataFlight_ID",
                table: "CheckIn_Details");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckIn_Details_Users_user_detailsUserName",
                table: "CheckIn_Details");

            migrationBuilder.RenameColumn(
                name: "user_detailsUserName",
                table: "CheckIn_Details",
                newName: "userDetailUserName");

            migrationBuilder.RenameColumn(
                name: "flight_dataFlight_ID",
                table: "CheckIn_Details",
                newName: "flightDataFlight_ID");

            migrationBuilder.RenameIndex(
                name: "IX_CheckIn_Details_user_detailsUserName",
                table: "CheckIn_Details",
                newName: "IX_CheckIn_Details_userDetailUserName");

            migrationBuilder.RenameIndex(
                name: "IX_CheckIn_Details_flight_dataFlight_ID",
                table: "CheckIn_Details",
                newName: "IX_CheckIn_Details_flightDataFlight_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckIn_Details_Flight_Datas_flightDataFlight_ID",
                table: "CheckIn_Details",
                column: "flightDataFlight_ID",
                principalTable: "Flight_Datas",
                principalColumn: "Flight_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckIn_Details_Users_userDetailUserName",
                table: "CheckIn_Details",
                column: "userDetailUserName",
                principalTable: "Users",
                principalColumn: "UserName",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckIn_Details_Flight_Datas_flightDataFlight_ID",
                table: "CheckIn_Details");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckIn_Details_Users_userDetailUserName",
                table: "CheckIn_Details");

            migrationBuilder.RenameColumn(
                name: "userDetailUserName",
                table: "CheckIn_Details",
                newName: "user_detailsUserName");

            migrationBuilder.RenameColumn(
                name: "flightDataFlight_ID",
                table: "CheckIn_Details",
                newName: "flight_dataFlight_ID");

            migrationBuilder.RenameIndex(
                name: "IX_CheckIn_Details_userDetailUserName",
                table: "CheckIn_Details",
                newName: "IX_CheckIn_Details_user_detailsUserName");

            migrationBuilder.RenameIndex(
                name: "IX_CheckIn_Details_flightDataFlight_ID",
                table: "CheckIn_Details",
                newName: "IX_CheckIn_Details_flight_dataFlight_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckIn_Details_Flight_Datas_flight_dataFlight_ID",
                table: "CheckIn_Details",
                column: "flight_dataFlight_ID",
                principalTable: "Flight_Datas",
                principalColumn: "Flight_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckIn_Details_Users_user_detailsUserName",
                table: "CheckIn_Details",
                column: "user_detailsUserName",
                principalTable: "Users",
                principalColumn: "UserName",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
