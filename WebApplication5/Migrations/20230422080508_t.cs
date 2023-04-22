using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication5.Migrations
{
    /// <inheritdoc />
    public partial class t : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Retailers_Accounts_AccountId1",
                table: "Retailers");

            migrationBuilder.DropForeignKey(
                name: "FK_Retailers_Admins_AdminId1",
                table: "Retailers");

            migrationBuilder.DropIndex(
                name: "IX_Retailers_AccountId1",
                table: "Retailers");

            migrationBuilder.DropIndex(
                name: "IX_Retailers_AdminId1",
                table: "Retailers");

            migrationBuilder.DropColumn(
                name: "AccountId1",
                table: "Retailers");

            migrationBuilder.DropColumn(
                name: "AdminId1",
                table: "Retailers");

            migrationBuilder.CreateTable(
                name: "AdminRetailer",
                columns: table => new
                {
                    Admin1AdminId = table.Column<int>(type: "int", nullable: false),
                    RetailersRetailerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminRetailer", x => new { x.Admin1AdminId, x.RetailersRetailerId });
                    table.ForeignKey(
                        name: "FK_AdminRetailer_Admins_Admin1AdminId",
                        column: x => x.Admin1AdminId,
                        principalTable: "Admins",
                        principalColumn: "AdminId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdminRetailer_Retailers_RetailersRetailerId",
                        column: x => x.RetailersRetailerId,
                        principalTable: "Retailers",
                        principalColumn: "RetailerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdminRetailer_RetailersRetailerId",
                table: "AdminRetailer",
                column: "RetailersRetailerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminRetailer");

            migrationBuilder.AddColumn<int>(
                name: "AccountId1",
                table: "Retailers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AdminId1",
                table: "Retailers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Retailers_AccountId1",
                table: "Retailers",
                column: "AccountId1",
                unique: true,
                filter: "[AccountId1] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Retailers_AdminId1",
                table: "Retailers",
                column: "AdminId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Retailers_Accounts_AccountId1",
                table: "Retailers",
                column: "AccountId1",
                principalTable: "Accounts",
                principalColumn: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Retailers_Admins_AdminId1",
                table: "Retailers",
                column: "AdminId1",
                principalTable: "Admins",
                principalColumn: "AdminId");
        }
    }
}
