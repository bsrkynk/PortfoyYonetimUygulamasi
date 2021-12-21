using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfoyYonetimUygulamasi.Entity.Dtos
{
    public class CreateTransactionDto
    {
        public string CoinName { get; set; }
        public double CoinPrice { get; set; }
        public double CoinAmount { get; set; }
        public double TotalAmount { get; set; }
    }
}
