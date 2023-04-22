using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication5.Migrations
{
    /// <inheritdoc />
    public partial class i : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Retailers_Accounts_AccountId",
                table: "Retailers");

            migrationBuilder.DropForeignKey(
                name: "FK_Retailers_Admins_AdminId",
                table: "Retailers");

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
                name: "FK_Retailers_Accounts_AccountId",
                table: "Retailers",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Retailers_Accounts_AccountId1",
                table: "Retailers",
                column: "AccountId1",
                principalTable: "Accounts",
                principalColumn: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Retailers_Admins_AdminId",
                table: "Retailers",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "AdminId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Retailers_Admins_AdminId1",
                table: "Retailers",
                column: "AdminId1",
                principalTable: "Admins",
                principalColumn: "AdminId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Retailers_Accounts_AccountId",
                table: "Retailers");

            migrationBuilder.DropForeignKey(
                name: "FK_Retailers_Accounts_AccountId1",
                table: "Retailers");

            migrationBuilder.DropForeignKey(
                name: "FK_Retailers_Admins_AdminId",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Retailers_Accounts_AccountId",
                table: "Retailers",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Retailers_Admins_AdminId",
                table: "Retailers",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "AdminId");
        }
    }
}
