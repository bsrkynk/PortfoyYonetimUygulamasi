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
        public string CoinPrice { get; set; }
        public string CoinAmount { get; set; }
        public string TotalAmount { get; set; }
        public int TransactionType { get; set; }
    }
}
