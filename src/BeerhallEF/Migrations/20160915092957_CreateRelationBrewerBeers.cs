using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BeerhallEF.Migrations
{
    public partial class CreateRelationBrewerBeers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BrewerId",
                table: "Beers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Beers_BrewerId",
                table: "Beers",
                column: "BrewerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Beers_Brewers_BrewerId",
                table: "Beers",
                column: "BrewerId",
                principalTable: "Brewers",
                principalColumn: "BrewerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beers_Brewers_BrewerId",
                table: "Beers");

            migrationBuilder.DropIndex(
                name: "IX_Beers_BrewerId",
                table: "Beers");

            migrationBuilder.DropColumn(
                name: "BrewerId",
                table: "Beers");
        }
    }
}
