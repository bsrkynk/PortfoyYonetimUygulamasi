using System;
using System.Collections.Generic;
using System.Text;
using PortfoyYonetimUygulamasi.Shared.Entities.Abstract;

namespace PortfoyYonetimUygulamasi.Entity.Concrete
{
    public class Portfolio : EntityBase, IEntity
    {
        public string PortfolioName { get; set; }
        public int UserId { get; set; }     //bir portföyün bir user ı olabilir.
        public User User { get; set; }
        public int WalletId { get; set; }
        public Wallet Wallet { get; set; } //bir portföyde bir cüzdan olabilir.
        public ICollection<Transaction> Transactions { get; set; } //bir portföyde çok sayıda transaction olabilir
    }
}
