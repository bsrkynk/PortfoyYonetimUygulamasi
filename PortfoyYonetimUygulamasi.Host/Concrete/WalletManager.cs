using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortfoyYonetimUygulamasi.Data.Abstract;
using PortfoyYonetimUygulamasi.Entity.Concrete;
using PortfoyYonetimUygulamasi.Host.Abstract;

namespace PortfoyYonetimUygulamasi.Host.Concrete
{
    public class WalletManager:IWalletService
    {
        private readonly IUnitOfWork _unitOfWork;

        public WalletManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<int> InitialWalletCreate(int portfolioId)
        {
            Wallet wallet = new Wallet
            {
                AmountOfCoin = 0,
                AvarageBuyPrice = 0,
                IsActive = true,
                IsDeleted = false,
                TotalWealth = 0,
                PortfolioId = portfolioId

            };

            await _unitOfWork.Wallets.AddAsync(wallet);

                await _unitOfWork.SaveAsync();
                return wallet.Id;
        }

    }
}
