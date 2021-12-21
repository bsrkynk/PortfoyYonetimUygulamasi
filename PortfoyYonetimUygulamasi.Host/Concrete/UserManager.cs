using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortfoyYonetimUygulamasi.Data.Abstract;
using PortfoyYonetimUygulamasi.Entity.Concrete;
using PortfoyYonetimUygulamasi.Entity.Dtos;
using PortfoyYonetimUygulamasi.Host.Abstract;

namespace PortfoyYonetimUygulamasi.Host.Concrete
{
    public class UserManager:IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Add(UserAddDto userAddDto)
        {
            await _unitOfWork.Users.AddAsync(new User
            {
                Name = userAddDto.Name,
                Surname = userAddDto.UserName,
                UserName = userAddDto.UserName,
                UserPassword = userAddDto.UserPassword,
                IsActive = true,
                IsDeleted = false

            });
            await _unitOfWork.SaveAsync();
            
        }

        public async Task<int> SignInUser(SignInUserDto signInUserDto)
        {
         return await 
             _unitOfWork.Users.SignInUser(new User
            {
                UserName = signInUserDto.UserName,
                UserPassword = signInUserDto.UserPassword
            });
            
        }
    }
}
