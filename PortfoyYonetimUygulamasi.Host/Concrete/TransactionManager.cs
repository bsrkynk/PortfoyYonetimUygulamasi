using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PortfoyYonetimUygulamasi.Data.Abstract;
using PortfoyYonetimUygulamasi.Entity.Concrete;
using PortfoyYonetimUygulamasi.Entity.Dtos;
using PortfoyYonetimUygulamasi.Host.Abstract;

namespace PortfoyYonetimUygulamasi.Host.Concrete
{
    public class TransactionManager : ITransactionService
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly ICoinService _coinService;
        private readonly IWalletService _walletService;
        private readonly ICoinWalletService _coinWalletService;
        public TransactionManager(IUnitOfWork unitOfWork, ICoinService coinService, IWalletService walletService, ICoinWalletService coinWalletService)
        {
            _UnitOfWork = unitOfWork;
            _coinService = coinService;
            _walletService = walletService;
            _coinWalletService = coinWalletService;
        }
        public async Task ManageTransaction(CreateTransactionDto addTransactionDto, int instancePortfolioId)
        {
            var addedCoin = await _coinService.AddCoin(addTransactionDto);
            var addedWallet = await _walletService.GetCreatedWalletId(instancePortfolioId);// her portföyde bir wallet olacağı için çoka çok tablosuna kayıt olması için portföy id den o portföyün walletının idsi bulunuyor.

            await _coinWalletService.AddCoinWallet(addedCoin, addedWallet);//coin wallet tablosuna kaydediyor.
            await AddTransaction(addTransactionDto, instancePortfolioId);
            var unifiedWalletCoin = await _coinWalletService.GetUnifiedCoinWallet(addedCoin, addedWallet);

            await DoWalletTransaction(addTransactionDto, unifiedWalletCoin);

        }

        public async Task AddTransaction(CreateTransactionDto addTransactionDto, int instancePortfolioId)
        {
            Transaction transaction = new Transaction
            {
                CoinName = addTransactionDto.CoinName,
                TotalPrice = addTransactionDto.CoinPrice,
                Amount = addTransactionDto.CoinAmount,
                PortfolioId = instancePortfolioId,
                TransactionPrice = addTransactionDto.TotalAmount,
                IsActive = true,
                IsDeleted = false,
                TransactionType = addTransactionDto.TransactionType.ToString()
            };
            await _UnitOfWork.Transactions.AddAsync(transaction);
            await _UnitOfWork.SaveAsync();
        }

        public async Task DoWalletTransaction(CreateTransactionDto createTransactionDto, IEnumerable<CoinWalletJoin> joinedCoinWallet)
        {
            if (createTransactionDto.TransactionType == "Buy")
            {
                await Buy(createTransactionDto, joinedCoinWallet);
            }
        }
        public async Task Buy(CreateTransactionDto createTransactionDto, IEnumerable<CoinWalletJoin> joinedCoinWallet)
        {

            Wallet wallet = new Wallet();
            _UnitOfWork.Wallets.DetachEntity();


            foreach (var coinWallet in joinedCoinWallet)
            {
                double amountOfCoin = Convert.ToDouble(coinWallet.AmountOfCoin);
                amountOfCoin += Convert.ToDouble(createTransactionDto.CoinAmount);
                wallet.AmountOfCoin = amountOfCoin.ToString();
                double totalWelth = Convert.ToDouble(coinWallet.TotalWelth);
                totalWelth += Convert.ToDouble(createTransactionDto.CoinPrice) *
                              Convert.ToDouble(createTransactionDto.CoinAmount);
                wallet.TotalWealth = totalWelth.ToString();
                double avarage = Convert.ToDouble(coinWallet.AvarageBuyPrice);
                avarage = totalWelth / amountOfCoin;
                wallet.AvarageBuyPrice = avarage.ToString();
                wallet.PortfolioId = coinWallet.PortfolioId;
                wallet.Id = coinWallet.WalletId;
            }

            wallet.IsDeleted = false;
            wallet.IsActive = true;

            await _UnitOfWork.Wallets.UpdateAsync(wallet).ContinueWith(t=>_UnitOfWork.SaveAsync());
       //     await _UnitOfWork.SaveAsync(); //ContinueWith(x =>

        }

    }
}
