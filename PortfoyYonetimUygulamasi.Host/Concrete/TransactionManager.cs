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
    public class TransactionManager:ITransactionService
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly ICoinService _coinService;
        private readonly IWalletService _walletService;
        private readonly  ICoinWalletService _coinWalletService;
        public TransactionManager(IUnitOfWork unitOfWork, ICoinService coinService, IWalletService walletService, ICoinWalletService coinWalletService)
        {
            _UnitOfWork = unitOfWork;
            _coinService = coinService;
            _walletService = walletService;
            _coinWalletService = coinWalletService;
        }
        public async Task ManageTransaction(CreateTransactionDto addTransactionDto, int instancePortfolioId)
        {
            var addedCoin=await _coinService.AddCoin(addTransactionDto); 
            var addedWallet = await _walletService.GetCreatedWalletId(instancePortfolioId);// her portföyde bir wallet olacağı için çoka çok tablosuna kayıt olması için portföy id den o portföyün walletının idsi bulunuyor.
            await _coinWalletService.AddCoinWallet(addedCoin, addedWallet);//coin wallet tablosuna kaydediyor.
            await AddTransaction(addTransactionDto, instancePortfolioId);

        }

        public async Task AddTransaction(CreateTransactionDto addTransactionDto, int instancePortfolioId)
        {
            Transaction transaction=new Transaction
            {
                CoinName = addTransactionDto.CoinName,
                TotalPrice = Convert.ToDouble(addTransactionDto.TotalAmount),
                Amount = Convert.ToDouble(addTransactionDto.CoinAmount),
                PortfolioId = instancePortfolioId,
                TransactionPrice = Convert.ToDouble(addTransactionDto.CoinPrice),
                IsActive = true,
                IsDeleted = true,
                TransactionTypeId = addTransactionDto.TransactionType
            };
            await _UnitOfWork.Transactions.AddAsync(transaction);
            await _UnitOfWork.SaveAsync();
        }
    }
}
