using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Migrations
{
    public partial class RegisteredToBool : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "registered",
                schema: "mtengure",
                table: "student",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<short>(
                name: "registered",
                schema: "mtengure",
                table: "student",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(bool));
        }
    }
}
