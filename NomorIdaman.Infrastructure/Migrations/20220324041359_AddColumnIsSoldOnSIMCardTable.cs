using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NomorIdaman.Infrastructure.Migrations
{
    public partial class AddColumnIsSoldOnSIMCardTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSold",
                table: "SIMCard",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSold",
                table: "SIMCard");
        }
    }
}
