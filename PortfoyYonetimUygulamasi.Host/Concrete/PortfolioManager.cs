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
    public class PortfolioManager:IPortfolioService
    {

        private readonly IUnitOfWork _unitOfWork;

        public PortfolioManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task Add(CreatePortfolioDto createPortfolioDto)
        {
            await _unitOfWork.Portfolios.AddAsync(new Portfolio
            {
                PortfolioName = createPortfolioDto.PortfolioName,
                UserId = createPortfolioDto.UserId,
                IsActive = true,
                IsDeleted = false
            });
            await _unitOfWork.SaveAsync();
        }

        public async Task<List<Portfolio>> GetAllUserPortfolios(int userId)
        {
            var result=await _unitOfWork.Portfolios.GetAllAsync(a => a.UserId == userId);
            return  result.ToList();
        }
        public async Task<List<Portfolio>> GetUserPortfolio(int portfolioId)
        {
            var result = await _unitOfWork.Portfolios.GetAllAsync(a => a.Id == portfolioId);
            return result.ToList();
        }
    }
}
