using Microsoft.EntityFrameworkCore.Migrations;

namespace PortfoyYonetimUygulamasi.Data.Migrations
{
    public partial class coinWalletTableUpdate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TotalWelthOfCoin",
                table: "CoinWallets",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalWelthOfCoin",
                table: "CoinWallets");
        }
    }
}
