using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication5.Migrations
{
    /// <inheritdoc />
    public partial class e : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Retailers_Admins_WebApplication5.Models.Retailer_AdminId",
                table: "Retailers");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Admins_TempId_TempId1",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "WebApplication5.Models.Retailer",
                table: "Retailers");

            migrationBuilder.DropColumn(
                name: "TempId",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "TempId1",
                table: "Admins");

            migrationBuilder.AddForeignKey(
                name: "FK_Retailers_Admins_AdminId",
                table: "Retailers",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "AdminId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Retailers_Admins_AdminId",
                table: "Retailers");

            migrationBuilder.AddColumn<int>(
                name: "WebApplication5.Models.Retailer",
                table: "Retailers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TempId",
                table: "Admins",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TempId1",
                table: "Admins",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Admins_TempId_TempId1",
                table: "Admins",
                columns: new[] { "TempId", "TempId1" });

            migrationBuilder.AddForeignKey(
                name: "FK_Retailers_Admins_WebApplication5.Models.Retailer_AdminId",
                table: "Retailers",
                columns: new[] { "WebApplication5.Models.Retailer", "AdminId" },
                principalTable: "Admins",
                principalColumns: new[] { "TempId", "TempId1" });
        }
    }
}
