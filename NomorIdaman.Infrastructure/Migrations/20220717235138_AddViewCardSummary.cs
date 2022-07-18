using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NomorIdaman.Infrastructure.Migrations {
    public partial class AddViewCardSummary : Migration {
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.Sql("CREATE VIEW SIMCardSummary AS " +
                                "SELECT P.Name AS CardName, COUNT(P.Name) Count " +
                                "FROM SIMCard S " +
                                "JOIN ProviderCard P ON S.ProviderCardId = P.Id " +
                                "JOIN Shop SH ON S.ShopId = SH.Id " +
                                "WHERE S.IsActive = 1 " +
                                "GROUP BY P.Name, S.ProviderCardId");
        }

        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.Sql("DROP VIEW SIMCardSummary");
        }
    }
}
