using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfoyYonetimUygulamasi.Host.Abstract
{
    public interface ICoinWalletService
    {
        Task AddCoinWallet(int coinId, int walletId);
    }
}
