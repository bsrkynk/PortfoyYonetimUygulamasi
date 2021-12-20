using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfoyYonetimUygulamasi.Entity.Dtos
{
    public class CreateWalletDto
    {
        public string CoinName { get; set; }
        public int CoinPrice { get; set; }
        public int CoinAmount { get; set; }
    }
}
