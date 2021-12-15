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
    public class WalletMap: IEntityTypeConfiguration<Wallet>
    {
        public void Configure(EntityTypeBuilder<Wallet> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();//bir bir artmasını sağlıyor

            

            builder.Property(a => a.IsDeleted).IsRequired(true);
            builder.Property(a => a.IsActive).IsRequired(true);

            builder.ToTable("Wallets");
        }
    }
}
