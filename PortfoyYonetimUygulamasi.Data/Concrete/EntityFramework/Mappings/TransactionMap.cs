using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortfoyYonetimUygulamasi.Entity.Concrete;

namespace PortfoyYonetimUygulamasi.Data.Concrete.EntityFramework.Mappings
{
   public class TransactionMap : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();//bir bir artmasını sağlıyor

            builder.Property(a => a.Amount).IsRequired(true);
            builder.Property(a => a.TransactionPrice).IsRequired(true);
            builder.Property(a => a.TotalPrice).IsRequired(true);

            builder.HasOne<Portfolio>(a => a.Portfolio).WithMany(c => c.Transactions).HasForeignKey(a => a.PortfolioId);

            builder.HasOne<TransactionType>(a => a.TransactionType).WithOne(c => c.Transaction)
                .HasForeignKey<TransactionType>(v => v.TransactionId);

            builder.HasOne<Coin>(a => a.Coin).WithMany(c => c.Transactions).HasForeignKey(x => x.CoinId);


            builder.Property(a => a.IsDeleted).IsRequired(true);
            builder.Property(a => a.IsActive).IsRequired(true);
            builder.ToTable("Transactions");
        }
    }
}
