using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Utkin_PP.Migrations
{
    /// <inheritdoc />
    public partial class updateDatabase1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "WorkInformation");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "WorkInformation");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "Date",
                table: "WorkInformation",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "WorkInformation",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
