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
    public class CoinManager:ICoinService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CoinManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<int> AddCoin(CreateTransactionDto addCoinDto)
        {
            var isExist=await _unitOfWork.Coins.AnyAsync(x => x.CoinName == addCoinDto.CoinName);

            if (isExist)
            {
                var coin = await _unitOfWork.Coins.GetAllAsync(x => x.CoinName == addCoinDto.CoinName);
                var coinId = coin.Select(x => x.Id).FirstOrDefault();
                return coinId;
            }
            else
            {
                Coin addCoin = new Coin
                {
                    CoinName = addCoinDto.CoinName,
                    CoinPrice = addCoinDto.CoinPrice
                };
                await _unitOfWork.Coins.AddAsync(addCoin);
                await _unitOfWork.SaveAsync();
                return addCoin.Id; //en son eklenen coinin idsini döndürür
            }
            
        }
    }
}
