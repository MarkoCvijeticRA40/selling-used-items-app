using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sellinguseditemsappbackend.Migrations
{
    /// <inheritdoc />
    public partial class TenthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_email",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_username",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Comments_userId_advertisementId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Comments",
                newName: "targetUserId");

            migrationBuilder.RenameColumn(
                name: "content",
                table: "Comments",
                newName: "message");

            migrationBuilder.AlterColumn<int>(
                name: "rating",
                table: "Comments",
                type: "integer",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AddColumn<int>(
                name: "creatorId",
                table: "Comments",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "creatorId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "targetUserId",
                table: "Comments",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "message",
                table: "Comments",
                newName: "content");

            migrationBuilder.AlterColumn<double>(
                name: "rating",
                table: "Comments",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateIndex(
                name: "IX_Users_email",
                table: "Users",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_username",
                table: "Users",
                column: "username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_userId_advertisementId",
                table: "Comments",
                columns: new[] { "userId", "advertisementId" },
                unique: true);
        }
    }
}
