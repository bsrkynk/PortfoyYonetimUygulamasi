using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PortfoyYonetimUygulamasi.Data.Concrete.EntityFramework.Mappings;
using PortfoyYonetimUygulamasi.Entity;
using PortfoyYonetimUygulamasi.Entity.Concrete;

namespace PortfoyYonetimUygulamasi.Data.Concrete.EntityFramework.Contexts
{
    public class PortfoyYonetimUygulamasiContext:DbContext
    {
        public DbSet<Coin> Coins { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<CoinWallet> CoinWallets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=.;Database=PortYonetimUygulamasi;Trusted_Connection=True;Connect Timeout=30;MultipleActiveResultSets=True;");
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         
                modelBuilder.ApplyConfiguration(new CoinMap());
                modelBuilder.ApplyConfiguration(new PortfolioMap());
                modelBuilder.ApplyConfiguration(new TransactionMap());
                modelBuilder.ApplyConfiguration(new UserMap());
                modelBuilder.ApplyConfiguration(new WalletMap());
                modelBuilder.ApplyConfiguration(new CoinWalletMap());
            
        }
    }
}
