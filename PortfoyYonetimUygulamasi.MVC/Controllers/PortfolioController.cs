using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using PortfoyYonetimUygulamasi.Entity.Dtos;
using PortfoyYonetimUygulamasi.Entity.User;
using System.Text.Json;
using PortfoyYonetimUygulamasi.Host.Abstract;
using PortfoyYonetimUygulamasi.Host.Controllers.User;
using PortfoyYonetimUygulamasi.MVC.Filters;
using PortfoyYonetimUygulamasi.MVC.ViewModels;
using Controller = Microsoft.AspNetCore.Mvc.Controller;
using SelectListItem = Microsoft.AspNetCore.Mvc.Rendering.SelectListItem;
using JsonResult = Microsoft.AspNetCore.Mvc.JsonResult;

namespace PortfoyYonetimUygulamasi.MVC.Controllers
{
    //[UserFilter]
    public class PortfolioController : Controller
    {
        private readonly IPortfolioService _portfolioService;
        private readonly PortfolioViewModel _portfolioViewModel;
        public PortfolioController(IPortfolioService portfolioService, PortfolioViewModel portfolioViewModel)
        {
            _portfolioService = portfolioService;
            _portfolioViewModel = portfolioViewModel;
        }
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public async Task<IActionResult> Index()
        {
            //Convert.ToInt32(HttpContext.Session.GetInt32("USERNAME")
            var portfolios = await _portfolioService.GetAllUserPortfolios(1);
            if (portfolios != null)
            {
                _portfolioViewModel.UserPortfolioes = portfolios;
            }

            return View(_portfolioViewModel);
        }
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public async Task<IActionResult> Index(int id, bool check)//////////////////////////////////////////////////////////PORTFÖY ID=COİN KAYDEDERKEN PORTFÖYDEN WALLETI BUL, TRANSACTION YAPARKEN BUNU KULLAN, WALLETA YAZDIMAK İÇİN BUNA BAK. İKİ NUMARALI PORTFÖY 1 NUMARALI WALLETI VE OLUŞTURULAN COİNİ KULLANIYOR ONA GÖRE YAZ SESSİONA AT
        {
            var portfolios = await _portfolioService.GetUserPortfolio(id);
            if (portfolios != null)
            {
                _portfolioViewModel.UserPortfolioes = portfolios;


            }
            //CreateWalletDto createWalletDto=new CreateWalletDto();
            //_portfolioViewModel.Coins=new List<CreateWalletDto>();
            
            List<_24HourExchange> _24HourExchangeList = Home.HomeIndex();
            //foreach (var x in _24HourExchangeList.ToList())
            //{
            //    createWalletDto.CoinName = x.symbol;
            //    _portfolioViewModel.Coins.Add(createWalletDto);

            //}

            //var _sdf = _portfolioViewModel.Coins.ToList();

            var coinNames = (from i in _24HourExchangeList.ToList()
                            select new SelectListItem
                            {
                                Text = i.symbol
                            }).ToList();
            ViewBag.dgr = coinNames;
            _portfolioViewModel.CheckPortfolioPartial = check;
            return View(_portfolioViewModel);
        }
        public JsonResult GetCoinName(string id)
        {
            List<_24HourExchange> _24HourExchangeList = Home.HomeIndex();
            var price = _24HourExchangeList.Where(x => x.symbol == id).Select(y => y.lastPrice).FirstOrDefault(); 
            var pricee = System.Text.Json.JsonSerializer.Serialize(price);
            return Json(pricee);
        }

        [Microsoft.AspNetCore.Mvc.HttpPost]
        public async Task<IActionResult> CreatePortfolio(PortfolioViewModel portPortfolioViewModel)
        {
            portPortfolioViewModel.createPortfolioDto.UserId = Convert.ToInt32(/*HttpContext.Session.GetInt32("USERNAME")*/1);
            await _portfolioService.AddPortfolio(portPortfolioViewModel.createPortfolioDto);
            return RedirectToAction("Index");
        }
    }
}
