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
        public Coin Coin { get; set; }
        public int WalletId { get; set; }
        public Wallet Wallet { get; set; }
    }
}
