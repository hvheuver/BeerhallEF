using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BeerhallEF.Migrations
{
    public partial class UpdateTableBrewers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Street",
                table: "Brewers",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Brewers",
                maxLength: 100,
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "ContactEmail",
                table: "Brewers",
                maxLength: 100,
                nullable: true);

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Brewers",
                newName: "BrewerName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Street",
                table: "Brewers",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BrewerName",
                table: "Brewers",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ContactEmail",
                table: "Brewers",
                nullable: true);

            migrationBuilder.RenameColumn(
                name: "BrewerName",
                table: "Brewers",
                newName: "Name");
        }
    }
}
