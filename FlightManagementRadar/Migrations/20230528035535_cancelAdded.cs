﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightManagementRadar.Migrations
{
    public partial class cancelAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isCanclled",
                table: "CheckIn_Details",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isCanclled",
                table: "CheckIn_Details");
        }
    }
}
