using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Migrations
{
    public partial class StudentRestructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NationalId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PhysicalAddress",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<Guid>(
                name: "user_id",
                schema: "mtengure",
                table: "student",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                schema: "mtengure",
                table: "student",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                schema: "mtengure",
                table: "student",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NationalId",
                schema: "mtengure",
                table: "student",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhysicalAddress",
                schema: "mtengure",
                table: "student",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                schema: "mtengure",
                table: "student");

            migrationBuilder.DropColumn(
                name: "LastName",
                schema: "mtengure",
                table: "student");

            migrationBuilder.DropColumn(
                name: "NationalId",
                schema: "mtengure",
                table: "student");

            migrationBuilder.DropColumn(
                name: "PhysicalAddress",
                schema: "mtengure",
                table: "student");

            migrationBuilder.AlterColumn<Guid>(
                name: "user_id",
                schema: "mtengure",
                table: "student",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NationalId",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhysicalAddress",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
