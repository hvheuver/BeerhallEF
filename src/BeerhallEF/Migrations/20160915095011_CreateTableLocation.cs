using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BeerhallEF.Migrations
{
    public partial class CreateTableLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    PostalCode = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.PostalCode);
                });

            migrationBuilder.AddColumn<string>(
                name: "LocationPostalCode",
                table: "Brewers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Brewers_LocationPostalCode",
                table: "Brewers",
                column: "LocationPostalCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Brewers_Locations_LocationPostalCode",
                table: "Brewers",
                column: "LocationPostalCode",
                principalTable: "Locations",
                principalColumn: "PostalCode",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Brewers_Locations_LocationPostalCode",
                table: "Brewers");

            migrationBuilder.DropIndex(
                name: "IX_Brewers_LocationPostalCode",
                table: "Brewers");

            migrationBuilder.DropColumn(
                name: "LocationPostalCode",
                table: "Brewers");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
