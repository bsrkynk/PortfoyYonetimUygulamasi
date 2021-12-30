using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfoyYonetimUygulamasi.Data.Abstract;
using PortfoyYonetimUygulamasi.Entity.Concrete;
using PortfoyYonetimUygulamasi.Entity.Dtos;
using PortfoyYonetimUygulamasi.Host.Abstract;

namespace PortfoyYonetimUygulamasi.Host.Concrete
{
    public class TransactionManager : ITransactionService
    {
     public   enum Side
        {
            Buy=1,
            Sell=2,
            Transfer=3
        }
    private readonly IUnitOfWork _unitOfWork;
        private readonly ICoinService _coinService;
        private readonly IWalletService _walletService;
        private readonly ICoinWalletService _coinWalletService;
        public TransactionManager(IUnitOfWork unitOfWork, ICoinService coinService, IWalletService walletService, ICoinWalletService coinWalletService)
        {
            _unitOfWork = unitOfWork;
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

            //burada var mı yok mu kontrolünü yap
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
            await _unitOfWork.Transactions.AddAsync(transaction);
            await _unitOfWork.SaveAsync();
        }
        public async Task DoWalletTransaction(CreateTransactionDto createTransactionDto, IEnumerable<CoinWalletJoin> joinedCoinWallet)
        {
         
            if (createTransactionDto.TransactionType == "Buy")
            {
                await ManageProccess(createTransactionDto, joinedCoinWallet, Side.Buy );
            }
            else if (createTransactionDto.TransactionType == "Sell")
            {
                await ManageProccess(createTransactionDto, joinedCoinWallet, Side.Sell);
            }
            else if (createTransactionDto.TransactionType == "Transfer")
            {
                await ManageProccess(createTransactionDto, joinedCoinWallet, Side.Transfer);
            }
        }
        public async Task ManageProccess(CreateTransactionDto createTransactionDto, IEnumerable<CoinWalletJoin> joinedCoinWallets, Side side )
        {
            var df = double.Parse(createTransactionDto.TotalAmount, CultureInfo.InvariantCulture);
            Wallet wallet = new Wallet();
            CoinWallet coinWallet = new CoinWallet();

            _unitOfWork.Wallets.DetachEntity();
            _unitOfWork.CoinWallets.DetachEntity();
            foreach (var joinedCoinWallet in joinedCoinWallets)
            {
                var totalWelthOfWallet = double.Parse(joinedCoinWallet.TotalWelthOfWallet, CultureInfo.InvariantCulture); //cüzdandaki toplam miktar (wallet tablosuna kaydolur)
                totalWelthOfWallet =totalWelthOfWallet+ (side==Side.Buy?1:-1) * double.Parse(createTransactionDto.TotalAmount, CultureInfo.InvariantCulture);
                wallet.TotalWealth = totalWelthOfWallet.ToString(CultureInfo.InvariantCulture);

                //ilgili coinin toplam adet sayısı
                var amountOfCoin = double.Parse(joinedCoinWallet.AmountOfCoin, CultureInfo.InvariantCulture);
                amountOfCoin =amountOfCoin+ (side == Side.Buy ? 1 : -1)*double.Parse(createTransactionDto.CoinAmount, CultureInfo.InvariantCulture);
                coinWallet.AmountOfCoin = amountOfCoin.ToString(CultureInfo.InvariantCulture);

                //ilgili coinini toplam sahip olunan fiyat miktarı
                var totalWelthOfCoin = double.Parse(joinedCoinWallet.TotalWelthOfCoin, CultureInfo.InvariantCulture);//ilgili coininin total sahip olunan fiyatı
                totalWelthOfCoin =totalWelthOfCoin+ (side == Side.Buy ? 1 : -1)* double.Parse(createTransactionDto.TotalAmount, CultureInfo.InvariantCulture);
                coinWallet.TotalWelthOfCoin = totalWelthOfCoin.ToString(CultureInfo.InvariantCulture);//ilgili coinin total sahip olunan yeni fiyatı (coinwallet tablosuna kaydolur)


                var avarage = totalWelthOfCoin / amountOfCoin;
                coinWallet.AvarageBuyPrice = avarage.ToString(CultureInfo.InvariantCulture);

                wallet.PortfolioId = joinedCoinWallet.PortfolioId;
                wallet.Id = joinedCoinWallet.WalletId;
                coinWallet.CoinId = joinedCoinWallet.CoinId;
                coinWallet.WalletId = joinedCoinWallet.WalletId;
                coinWallet.Id = joinedCoinWallet.CoinWalletId;
            }
            wallet.IsDeleted = false;
            wallet.IsActive = true;
            coinWallet.IsActive = true;
            coinWallet.IsDeleted = false;

            await _unitOfWork.CoinWallets.UpdateAsync(coinWallet);
            await _unitOfWork.Wallets.UpdateAsync(wallet); //.ContinueWith(t=>_UnitOfWork.SaveAsync())
            await _unitOfWork.SaveAsync(); //ContinueWith(x =>

        }
    }
}
