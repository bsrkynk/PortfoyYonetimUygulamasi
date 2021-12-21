using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortfoyYonetimUygulamasi.Entity;
using PortfoyYonetimUygulamasi.Entity.Concrete;

namespace PortfoyYonetimUygulamasi.Data.Concrete.EntityFramework.Mappings
{
    public class CoinWalletMap:IEntityTypeConfiguration<CoinWallet>
    {
    public void Configure(EntityTypeBuilder<CoinWallet> builder)
    {
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Id).ValueGeneratedOnAdd(); //bir bir artmasını sağlıyor


        builder.ToTable("CoinWallets");

    }
}

}