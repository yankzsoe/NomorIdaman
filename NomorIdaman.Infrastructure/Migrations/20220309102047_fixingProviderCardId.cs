using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NomorIdaman.Infrastructure.Migrations
{
    public partial class fixingProviderCardId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SIMCard_ProviderCard_ProviderCardId",
                table: "SIMCard");

            migrationBuilder.DropColumn(
                name: "ProviderId",
                table: "SIMCard");

            migrationBuilder.AlterColumn<int>(
                name: "ProviderCardId",
                table: "SIMCard",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SIMCard_ProviderCard_ProviderCardId",
                table: "SIMCard",
                column: "ProviderCardId",
                principalTable: "ProviderCard",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SIMCard_ProviderCard_ProviderCardId",
                table: "SIMCard");

            migrationBuilder.AlterColumn<int>(
                name: "ProviderCardId",
                table: "SIMCard",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ProviderId",
                table: "SIMCard",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_SIMCard_ProviderCard_ProviderCardId",
                table: "SIMCard",
                column: "ProviderCardId",
                principalTable: "ProviderCard",
                principalColumn: "Id");
        }
    }
}
