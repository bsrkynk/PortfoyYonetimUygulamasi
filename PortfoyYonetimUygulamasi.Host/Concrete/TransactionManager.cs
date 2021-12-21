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
        public TransactionManager(IUnitOfWork unitOfWork, ICoinService coinService, IWalletService walletService)
        {
            _UnitOfWork = unitOfWork;
            _coinService = coinService;
            _walletService = walletService;
        }

        public async Task BeginTransaction(AddCoinDto addCoinDto, int instancePortfolioId)
        {
            var addedCoin=await _coinService.AddCoin(addCoinDto); 
            var addedWallet = await _walletService.GetCreatedWalletId(instancePortfolioId);// her portföyde bir wallet olacağı için çoka çok tablosuna kayıt olması için portföy id den o portföyün walletının idsi bulunuyor.

        }
     
    }
}
