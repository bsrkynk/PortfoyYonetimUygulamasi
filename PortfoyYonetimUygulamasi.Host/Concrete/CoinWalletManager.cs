﻿using System;
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
        public async Task<List<CoinWalletJoin>> GetUserWallet(int portfolioId)
        {
            var userWallet = await _unitOfWork.CoinWallets.GetAllAsync(x => x.Wallet.PortfolioId == portfolioId, y => y.Wallet, z => z.Coin);
            var uw = userWallet.Select(x =>new CoinWalletJoin{CoinName=x.Coin.CoinName,AmountOfCoin = x.AmountOfCoin,TotalWelthOfWallet = x.Wallet.TotalWealth,AvarageBuyPrice = x.AvarageBuyPrice,TotalWelthOfCoin = x.TotalWelthOfCoin } ).ToList();
                //&&} x.AmountOfCoin && x.Wallet.TotalWealth && x.AvarageBuyPrice && x.TotalWelthOfCoin
            return uw.ToList();
        }

        public async Task AddCoinWallet(int coinId, int walletId)
        {
            var isExist = await _unitOfWork.CoinWallets.AnyAsync(x => x.CoinId == coinId && x.WalletId == walletId);
            if (!isExist)
            {
                CoinWallet addCoinWallet = new CoinWallet
                {
                    CoinId = coinId,
                    WalletId = walletId,
                    IsActive = true,
                    IsDeleted = false,
                    AmountOfCoin = "0",
                    AvarageBuyPrice = "0",
                    TotalWelthOfCoin = "0"

                };
                await _unitOfWork.CoinWallets.AddAsync(addCoinWallet);
                await _unitOfWork.SaveAsync();
            }
        }

        public async Task<IEnumerable<CoinWalletJoin>> GetUnifiedCoinWallet(int coinId, int walletId)
        {
            var coinWallet = await _unitOfWork.CoinWallets.GetAllAsync(x => x.WalletId == walletId && x.CoinId == coinId); //x numaralı wallettaki y numaralı coini getirir
            var coin = await _unitOfWork.Coins.GetAllAsync(x => x.Id == coinId);
            var wallet = await _unitOfWork.Wallets.GetAllAsync(x => x.Id == walletId);
            var query = from cw in coinWallet
                        join
                            c in coin on cw.CoinId equals c.Id
                        join w in wallet on cw.WalletId equals w.Id
                        select new CoinWalletJoin
                        {
                            CoinId = c.Id,
                            WalletId = w.Id,
                            CoinPrice = c.CoinPrice,
                            TotalWelthOfWallet = w.TotalWealth,
                            AvarageBuyPrice = cw.AvarageBuyPrice,
                            AmountOfCoin = cw.AmountOfCoin,
                            PortfolioId = w.PortfolioId,
                            CoinWalletId = cw.Id,
                            TotalWelthOfCoin = cw.TotalWelthOfCoin
                        };
            return query.ToList();
        }

    }
}
