using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoneyRate.Migrations
{
    public partial class OnMainToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CountryName",
                table: "Rate",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "OnMainPage",
                table: "Rate",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OnMainPage",
                table: "Rate");

            migrationBuilder.AlterColumn<string>(
                name: "CountryName",
                table: "Rate",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}
