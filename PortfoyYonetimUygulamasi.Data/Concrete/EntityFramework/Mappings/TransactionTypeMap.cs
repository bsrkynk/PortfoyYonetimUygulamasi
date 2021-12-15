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
    class TransactionTypeMap : IEntityTypeConfiguration<TransactionType>
    {

        public void Configure(EntityTypeBuilder<TransactionType> builder)
        {

            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();//bir bir artmasını sağlıyor

            builder.Property(a => a.TransactionTypeName).HasMaxLength(100);
            builder.Property(a => a.TransactionTypeName).IsRequired(true);

            builder.Property(a => a.IsDeleted).IsRequired(true);
            builder.Property(a => a.IsActive).IsRequired(true);

            builder.ToTable("TransactionTypes");
        }
    }
}
