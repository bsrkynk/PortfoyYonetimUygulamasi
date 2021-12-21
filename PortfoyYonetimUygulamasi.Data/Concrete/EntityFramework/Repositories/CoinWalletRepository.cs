using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PortfoyYonetimUygulamasi.Data.Abstract;
using PortfoyYonetimUygulamasi.Entity;
using PortfoyYonetimUygulamasi.Entity.Concrete;
using PortfoyYonetimUygulamasi.Shared.Data.Concrete;

namespace PortfoyYonetimUygulamasi.Data.Concrete.EntityFramework.Repositories
{
    public class CoinWalletRepository : EfEntityRepositoryBase<CoinWallet>, ICoinWalletRepository
    {
        public CoinWalletRepository(DbContext context) : base(context)
        {
        }

    }
}
