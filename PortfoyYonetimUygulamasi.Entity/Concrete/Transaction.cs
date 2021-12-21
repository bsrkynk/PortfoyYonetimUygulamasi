using System;
using System.Collections.Generic;
using System.Text;
using PortfoyYonetimUygulamasi.Shared.Entities.Abstract;

namespace PortfoyYonetimUygulamasi.Entity.Concrete
{
    public class Transaction:EntityBase,IEntity
    {
        /// <summary>
        /// işlemin miktarını belirtir. 
        /// </summary>
        public string Amount { get; set; }
        /// <summary>
        /// yapılan işlemin fiyatını belirtir.
        /// </summary>
        public string TransactionPrice { get; set; }
        /// <summary>
        /// miktar çarpı fiyatı belirtir.
        /// </summary>
        public string TotalPrice { get; set; }
        public string CoinName { get; set; }
        //   public int CoinId { get; set; }
        //    public Coin Coin { get; set; }

        public string TransactionType { get; set; }
        public int PortfolioId { get; set; }
        public Portfolio Portfolio { get; set; } //bir transaction bir portföye ait olabilir
    }
}
