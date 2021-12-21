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
        public TransactionManager(IUnitOfWork unitOfWork, ICoinService coinService)
        {
            _UnitOfWork = unitOfWork;
            _coinService = coinService;
        }

        public async Task AddCoin(AddCoinDto addCoinDto)
        {
            Coin addCoin=new Coin
            {
                CoinName = addCoinDto.CoinName,
                CoinPrice = addCoinDto.CoinPrice
            };
            await _UnitOfWork.Coins.AddAsync(addCoin);
            await _UnitOfWork.SaveAsync();


        }
    }
}
