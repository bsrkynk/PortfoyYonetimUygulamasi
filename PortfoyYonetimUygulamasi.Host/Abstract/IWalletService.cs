using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfoyYonetimUygulamasi.Host.Abstract
{
    public interface IWalletService
    {
        Task<int> InitialWalletCreate(int portfolioId);
        Task<int> GetCreatedWalletId(int portfolioId);
    }
}
