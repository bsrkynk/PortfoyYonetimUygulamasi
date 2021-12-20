using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PortfoyYonetimUygulamasi.Entity.Concrete;
using PortfoyYonetimUygulamasi.Entity.Dtos;

namespace PortfoyYonetimUygulamasi.MVC.ViewModels
{
    public class PortfolioViewModel
    {
        public CreatePortfolioDto createPortfolioDto { get; set; }
        public bool CheckPortfolioPartial { get; set; } = false;
        public List<Portfolio> UserPortfolioes { get; set; }
        public int PortfolioId { get; set; }
        public List<CreateWalletDto> Coins { get; set; }
        public CreateWalletDto CreateWalletDto { get; set; }
    }
}
