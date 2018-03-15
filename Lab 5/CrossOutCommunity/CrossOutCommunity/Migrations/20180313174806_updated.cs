using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CrossOutCommunity.Migrations
{
    public partial class updated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_ContactUserID",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_ContactUserID",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "ContactUserID",
                table: "Messages");

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Messages",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_UserID",
                table: "Messages",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_UserID",
                table: "Messages",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_UserID",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_UserID",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Messages");

            migrationBuilder.AddColumn<int>(
                name: "ContactUserID",
                table: "Messages",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ContactUserID",
                table: "Messages",
                column: "ContactUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_ContactUserID",
                table: "Messages",
                column: "ContactUserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
