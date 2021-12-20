using System;
using System.Collections.Generic;
using System.Text;
using PortfoyYonetimUygulamasi.Shared.Entities.Abstract;

namespace PortfoyYonetimUygulamasi.Entity.Concrete
{
    public class Coin : EntityBase, IEntity 
    {
        public string CoinName { get; set; }
        public string CoinPrice { get; set; }
        public ICollection<Transaction> Transactions { get; set; }//bir coin çok transacactionda olabilir.
        public ICollection<Wallet> Wallets { get; set; } //bir walletta çok sayıda coin olabilir.
    }
}
