using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PortfoyYonetimUygulamasi.Data.Abstract;
using PortfoyYonetimUygulamasi.Entity.Concrete;
using PortfoyYonetimUygulamasi.Entity.Dtos;
using PortfoyYonetimUygulamasi.Shared.Data.Concrete;

namespace PortfoyYonetimUygulamasi.Data.Concrete
{
    public class UserRepository:EfEntityRepositoryBase<User>,IUserRepository
    {
        private readonly DbContext _context;

        public UserRepository(DbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<int> SignInUser(User user)
        {

            var result =await _context.Set<User>().FirstOrDefaultAsync(x => x.UserName.Equals(user.UserName) && x.UserPassword.Equals(user.UserPassword));
            if (result != null)
            {
                return result.Id;
            }
            return  -1;
        }
    }
}
