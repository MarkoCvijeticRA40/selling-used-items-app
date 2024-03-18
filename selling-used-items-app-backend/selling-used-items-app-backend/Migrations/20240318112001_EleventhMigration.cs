using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sellinguseditemsappbackend.Migrations
{
    /// <inheritdoc />
    public partial class EleventhMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "advertisementStatus",
                table: "Advertisements");

            migrationBuilder.AddColumn<int>(
                name: "purchaseStatus",
                table: "Purchases",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "purchaseStatus",
                table: "Purchases");

            migrationBuilder.AddColumn<int>(
                name: "advertisementStatus",
                table: "Advertisements",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
