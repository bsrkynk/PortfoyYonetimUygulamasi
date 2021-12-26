using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortfoyYonetimUygulamasi.Entity.Concrete;
using PortfoyYonetimUygulamasi.Shared.Entities.Abstract;

namespace PortfoyYonetimUygulamasi.Entity.Concrete
{
    public class CoinWallet:EntityBase, IEntity
    {
        public int CoinId { get; set; }
        /// <summary>
        /// ilgili coinin ortalama alış maliyetini gösterir 
        /// </summary>
        public string AvarageBuyPrice { get; set; }
        /// <summary>
        /// ilgili coin bazında sahip olunan coin adetini gösterir
        /// </summary>
        public string AmountOfCoin { get; set; }
        /// <summary>
        /// ilgili coin bazında sahip olunan toplam değeri gösterir
        /// </summary>
        public string TotalWelthOfCoin { get; set; }
        public Coin Coin { get; set; }
        public int WalletId { get; set; }
        public Wallet Wallet { get; set; }
    }
}
