using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Migrations
{
    public partial class UserRestructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "book_has_student$fk_book_has_student_user1",
                schema: "mtengure",
                table: "book_has_student");

            migrationBuilder.DropForeignKey(
                name: "canteen_balance$fk_canteen_balance_user1",
                schema: "mtengure",
                table: "canteen_balance");

            migrationBuilder.DropIndex(
                name: "fk_canteen_balance_user1_idx",
                schema: "mtengure",
                table: "canteen_balance");

            migrationBuilder.DropIndex(
                name: "fk_book_has_student_user1_idx",
                schema: "mtengure",
                table: "book_has_student");

            migrationBuilder.DropColumn(
                name: "user_id",
                schema: "mtengure",
                table: "canteen_balance");

            migrationBuilder.DropColumn(
                name: "user_id",
                schema: "mtengure",
                table: "book_has_student");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "user_id",
                schema: "mtengure",
                table: "canteen_balance",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "user_id",
                schema: "mtengure",
                table: "book_has_student",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "fk_canteen_balance_user1_idx",
                schema: "mtengure",
                table: "canteen_balance",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "fk_book_has_student_user1_idx",
                schema: "mtengure",
                table: "book_has_student",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "book_has_student$fk_book_has_student_user1",
                schema: "mtengure",
                table: "book_has_student",
                column: "user_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "canteen_balance$fk_canteen_balance_user1",
                schema: "mtengure",
                table: "canteen_balance",
                column: "user_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
