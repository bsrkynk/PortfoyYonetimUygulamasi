using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Internal;
using PortfoyYonetimUygulamasi.Data.Abstract;
using PortfoyYonetimUygulamasi.Entity.Concrete;
using PortfoyYonetimUygulamasi.Entity.Dtos;
using PortfoyYonetimUygulamasi.Host.Abstract;

namespace PortfoyYonetimUygulamasi.Host.Concrete
{
    public class CoinWalletManager : ICoinWalletService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CoinWalletManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddCoinWallet(int coinId, int walletId)
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

        public async Task<IEnumerable<CoinWalletJoin>> GetUnifiedCoinWallet(int coinId, int walletId)
        {
            var coinWallet = await _unitOfWork.CoinWallets.GetAllAsync(x => x.WalletId == walletId && x.CoinId == coinId) ; //x numaralı wallettaki y numaralı coini getirir
            var coin = await _unitOfWork.Coins.GetAllAsync(x => x.Id == coinId);
            var wallet = await _unitOfWork.Wallets.GetAllAsync(x => x.Id == walletId);
            var query = from cw in coinWallet
                join
                    c in coin on cw.CoinId equals c.Id
                join w in wallet on cw.WalletId equals w.Id
                select new CoinWalletJoin
                {
                    CoinId = c.Id, WalletId = w.Id, CoinPrice = c.CoinPrice, TotalWelth = w.TotalWealth,
                    AvarageBuyPrice = w.AvarageBuyPrice, AmountOfCoin = w.AmountOfCoin, PortfolioId = w.PortfolioId
                };
            return  query.ToList() ;
        }
    }
}
