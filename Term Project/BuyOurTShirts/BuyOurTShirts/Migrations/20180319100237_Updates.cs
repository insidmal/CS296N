using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BuyOurTShirts.Migrations
{
    public partial class Updates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Media_AspNetUsers_accountId",
                table: "Media");

            migrationBuilder.DropForeignKey(
                name: "FK_Show_Venue_venueID",
                table: "Show");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Media_accountId",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "accountId",
                table: "Media");

            migrationBuilder.RenameColumn(
                name: "venueID",
                table: "Show",
                newName: "VenueID");

            migrationBuilder.RenameIndex(
                name: "IX_Show_venueID",
                table: "Show",
                newName: "IX_Show_VenueID");

            migrationBuilder.AlterColumn<int>(
                name: "VenueID",
                table: "Show",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AccountId",
                table: "Blog",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_Show_Venue_VenueID",
                table: "Show",
                column: "VenueID",
                principalTable: "Venue",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Show_Venue_VenueID",
                table: "Show");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Blog");

            migrationBuilder.RenameColumn(
                name: "VenueID",
                table: "Show",
                newName: "venueID");

            migrationBuilder.RenameIndex(
                name: "IX_Show_VenueID",
                table: "Show",
                newName: "IX_Show_venueID");

            migrationBuilder.AlterColumn<int>(
                name: "venueID",
                table: "Show",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "accountId",
                table: "Media",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    accountId = table.Column<string>(nullable: true),
                    comment = table.Column<string>(nullable: true),
                    date = table.Column<DateTime>(nullable: false),
                    parentId = table.Column<int>(nullable: false),
                    parentType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Comment_AspNetUsers_accountId",
                        column: x => x.accountId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Media_accountId",
                table: "Media",
                column: "accountId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_accountId",
                table: "Comment",
                column: "accountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Media_AspNetUsers_accountId",
                table: "Media",
                column: "accountId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Show_Venue_venueID",
                table: "Show",
                column: "venueID",
                principalTable: "Venue",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
