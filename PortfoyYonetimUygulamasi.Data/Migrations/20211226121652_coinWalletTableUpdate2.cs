using Microsoft.EntityFrameworkCore.Migrations;

namespace PortfoyYonetimUygulamasi.Data.Migrations
{
    public partial class coinWalletTableUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmountOfCoin",
                table: "Wallets");

            migrationBuilder.DropColumn(
                name: "AvarageBuyPrice",
                table: "Wallets");

            migrationBuilder.AddColumn<string>(
                name: "AmountOfCoin",
                table: "CoinWallets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AvarageBuyPrice",
                table: "CoinWallets",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmountOfCoin",
                table: "CoinWallets");

            migrationBuilder.DropColumn(
                name: "AvarageBuyPrice",
                table: "CoinWallets");

            migrationBuilder.AddColumn<string>(
                name: "AmountOfCoin",
                table: "Wallets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AvarageBuyPrice",
                table: "Wallets",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
