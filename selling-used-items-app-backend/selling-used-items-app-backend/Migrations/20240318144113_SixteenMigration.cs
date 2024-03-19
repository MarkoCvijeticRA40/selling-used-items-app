using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sellinguseditemsappbackend.Migrations
{
    /// <inheritdoc />
    public partial class SixteenMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isApproved",
                table: "Comments",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isApproved",
                table: "Comments");
        }
    }
}
