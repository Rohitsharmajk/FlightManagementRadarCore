using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightManagementRadar.Migrations
{
    public partial class madenullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckIn_Details_Flight_Datas_flightDataFlight_ID",
                table: "CheckIn_Details");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckIn_Details_Users_userDetailUserName",
                table: "CheckIn_Details");

            migrationBuilder.AlterColumn<string>(
                name: "userDetailUserName",
                table: "CheckIn_Details",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "flightDataFlight_ID",
                table: "CheckIn_Details",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckIn_Details_Flight_Datas_flightDataFlight_ID",
                table: "CheckIn_Details",
                column: "flightDataFlight_ID",
                principalTable: "Flight_Datas",
                principalColumn: "Flight_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckIn_Details_Users_userDetailUserName",
                table: "CheckIn_Details",
                column: "userDetailUserName",
                principalTable: "Users",
                principalColumn: "UserName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckIn_Details_Flight_Datas_flightDataFlight_ID",
                table: "CheckIn_Details");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckIn_Details_Users_userDetailUserName",
                table: "CheckIn_Details");

            migrationBuilder.AlterColumn<string>(
                name: "userDetailUserName",
                table: "CheckIn_Details",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "flightDataFlight_ID",
                table: "CheckIn_Details",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
    }
}
