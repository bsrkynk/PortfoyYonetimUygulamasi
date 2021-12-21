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
        public async Task<int> AddCoin(AddCoinDto addCoinDto)
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
