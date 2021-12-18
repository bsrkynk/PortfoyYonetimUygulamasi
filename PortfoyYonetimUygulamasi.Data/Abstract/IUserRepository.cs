using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortfoyYonetimUygulamasi.Entity.Concrete;
using PortfoyYonetimUygulamasi.Entity.Dtos;
using PortfoyYonetimUygulamasi.Shared.Data.Abstract;

namespace PortfoyYonetimUygulamasi.Data.Abstract
{
    public interface IUserRepository:IEntityRepository<User>
    {
        Task<bool> SignInUser(User user);
    }
}
