﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sellinguseditemsappbackend.Migrations
{
    /// <inheritdoc />
    public partial class _110Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "image",
                table: "Advertisements",
                type: "bytea",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "image",
                table: "Advertisements");
        }
    }
}
