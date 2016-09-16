using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BeerhallEF.Migrations
{
    public partial class UpdateTableCourses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Courses",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Courses",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "From",
                table: "Courses",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfDays",
                table: "Courses",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Courses",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Till",
                table: "Courses",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "From",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "NumberOfDays",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Till",
                table: "Courses");
        }
    }
}
