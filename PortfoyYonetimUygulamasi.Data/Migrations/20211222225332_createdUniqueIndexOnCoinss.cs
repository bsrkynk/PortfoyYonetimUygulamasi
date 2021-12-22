using Microsoft.EntityFrameworkCore.Migrations;

namespace PortfoyYonetimUygulamasi.Data.Migrations
{
    public partial class createdUniqueIndexOnCoinss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Coins_CoinName",
                table: "Coins",
                column: "CoinName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Coins_CoinName",
                table: "Coins");
        }
    }
}
