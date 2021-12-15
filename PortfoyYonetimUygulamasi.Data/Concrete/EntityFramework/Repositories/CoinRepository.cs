using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PortfoyYonetimUygulamasi.Data.Abstract;
using PortfoyYonetimUygulamasi.Entity.Concrete;
using PortfoyYonetimUygulamasi.Shared.Data.Concrete;

namespace PortfoyYonetimUygulamasi.Data.Concrete
{
    public class CoinRepository:EfEntityRepositoryBase<Coin>,ICoinRepository
    {
        public CoinRepository(DbContext context) : base(context)
        {
        }
    }
}
