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
        public double Amount { get; set; }
        /// <summary>
        /// yapılan işlemin fiyatını belirtir.
        /// </summary>
        public double TransactionPrice { get; set; }
        /// <summary>
        /// miktar çarpı fiyatı belirtir.
        /// </summary>
        public double TotalPrice { get; set; }
        public string CoinName { get; set; }
        //   public int CoinId { get; set; }
        //    public Coin Coin { get; set; }
        public TransactionType TransactionType { get; set; }
        public int TransactionTypeId { get; set; }
        public int PortfolioId { get; set; }
        public Portfolio Portfolio { get; set; } //bir transaction bir portföye ait olabilir
    }
}
