using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortfoyYonetimUygulamasi.Entity.Concrete;

namespace PortfoyYonetimUygulamasi.Data.Concrete.EntityFramework.Mappings
{
    public class CoinMap : IEntityTypeConfiguration<Coin>
    {
        public void Configure(EntityTypeBuilder<Coin> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();//bir bir artmasını sağlıyor
            builder.Property(a => a.CoinName).HasMaxLength(100);
            builder.Property(a => a.CoinName).IsRequired(true);

            builder.Property(a => a.IsDeleted).IsRequired(true);
            builder.Property(a => a.IsActive).IsRequired(true);

            builder.ToTable("Coins");

        }
    }
}
