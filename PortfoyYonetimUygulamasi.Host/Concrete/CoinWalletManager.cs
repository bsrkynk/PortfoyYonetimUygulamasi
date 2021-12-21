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
    public class CoinWalletManager:ICoinWalletService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CoinWalletManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddCoinWallet(int coinId,int walletId)
        {
            CoinWallet addCoinWallet = new CoinWallet
            {
             CoinId = coinId,
             WalletId = walletId,
             IsActive = true,
             IsDeleted = false
            };
            await _unitOfWork.CoinWallets.AddAsync(addCoinWallet);
            await _unitOfWork.SaveAsync();
        }
    }
}
