using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfoyYonetimUygulamasi.Entity.Dtos
{
    public class CoinWalletJoin
    {
        public int CoinWalletId { get; set; }
        public string TotalWelthOfCoin { get; set; }
        public int WalletId { get; set; }
        public int CoinId { get; set; }
        public int PortfolioId { get; set; }
        public string CoinPrice { get; set; }
        public string TotalWelthOfWallet { get; set; }  //coinprice totalwelth e eklenecek
        public string AmountOfCoin { get; set; }  //transactionddddto dan gelen veri buna eklenecek
        public string AvarageBuyPrice { get; set; } //coinprice ve amountofcoin kullanılarak hesaplanıcak
        public string CoinName { get; set; }

    }
}
