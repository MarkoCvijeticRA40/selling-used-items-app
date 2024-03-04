using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sellinguseditemsappbackend.Migrations
{
    /// <inheritdoc />
    public partial class FourthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "dateCreated",
                table: "Advertisements",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "location",
                table: "Advertisements",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "price",
                table: "Advertisements",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dateCreated",
                table: "Advertisements");

            migrationBuilder.DropColumn(
                name: "location",
                table: "Advertisements");

            migrationBuilder.DropColumn(
                name: "price",
                table: "Advertisements");
        }
    }
}
