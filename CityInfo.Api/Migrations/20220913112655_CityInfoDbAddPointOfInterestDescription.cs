﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityInfo.Api.Migrations
{
    public partial class CityInfoDbAddPointOfInterestDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "PointsOfInterest",
                type: "TEXT",
                maxLength: 200,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "PointsOfInterest");
        }
    }
}
