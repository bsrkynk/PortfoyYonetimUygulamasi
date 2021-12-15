using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortfoyYonetimUygulamasi.Entity.Concrete;
using PortfoyYonetimUygulamasi.Shared.Data.Abstract;

namespace PortfoyYonetimUygulamasi.Data.Abstract
{
    public interface ICoinRepository:IEntityRepository<Coin>
    {
    }
}
