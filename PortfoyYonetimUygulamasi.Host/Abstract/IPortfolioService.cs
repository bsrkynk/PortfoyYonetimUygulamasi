using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortfoyYonetimUygulamasi.Entity.Concrete;
using PortfoyYonetimUygulamasi.Entity.Dtos;

namespace PortfoyYonetimUygulamasi.Host.Abstract
{
    public  interface IPortfolioService
    {
        Task AddPortfolio(CreatePortfolioDto userAddDto);
        Task<List<Portfolio>> GetAllUserPortfolios(int userId);
        public Task<List<Portfolio>> GetUserPortfolio(int portfolioId);
    }
}
