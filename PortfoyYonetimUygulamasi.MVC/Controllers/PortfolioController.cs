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
using RestSharp;
using Controller = Microsoft.AspNetCore.Mvc.Controller;
using SelectListItem = Microsoft.AspNetCore.Mvc.Rendering.SelectListItem;
using JsonResult = Microsoft.AspNetCore.Mvc.JsonResult;

namespace PortfoyYonetimUygulamasi.MVC.Controllers
{
    [UserFilter]
    public class PortfolioController : Controller
    {
        private readonly IPortfolioService _portfolioService;
        private readonly ITransactionService _transactionService;
        private readonly ICoinWalletService _coinWalletService;
        private readonly PortfolioViewModel _portfolioViewModel;
        public PortfolioController(IPortfolioService portfolioService, PortfolioViewModel portfolioViewModel, ITransactionService transactionService, ICoinWalletService coinWalletService)
        {
            _portfolioService = portfolioService;
            _portfolioViewModel = portfolioViewModel;
            _transactionService = transactionService;
            _coinWalletService = coinWalletService;
        }
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public async Task<IActionResult> Index()
        {
            //Convert.ToInt32(HttpContext.Session.GetInt32("USERNAME")
            var portfolios = await _portfolioService.GetAllUserPortfolios(Convert.ToInt32(HttpContext.Session.GetInt32("USERNAME")));
            if (portfolios != null)
            {
                _portfolioViewModel.UserPortfolioes = portfolios;
            }


            return View(_portfolioViewModel);
        }
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public async Task<IActionResult> Index(int id, bool check)//////////////////////////////////////////////////////////PORTFÖY ID=COİN KAYDEDERKEN PORTFÖYDEN WALLETI BUL, TRANSACTION YAPARKEN BUNU KULLAN, WALLETA YAZDIMAK İÇİN BUNA BAK. İKİ NUMARALI PORTFÖY 1 NUMARALI WALLETI VE OLUŞTURULAN COİNİ KULLANIYOR ONA GÖRE YAZ SESSİONA AT
        {
            HttpContext.Session.SetInt32("PortfolioId", id);
            var portfolios = await _portfolioService.GetUserPortfolio(id);
            if (portfolios != null)
            {
                _portfolioViewModel.UserPortfolioes = portfolios;
            }
            List<_24HourExchange> _24HourExchangeList = Home.HomeIndex();

            var coinNames = (from i in _24HourExchangeList.ToList()
                            select new SelectListItem
                            {
                                Text = i.symbol
                            }).ToList();
            ViewBag.dgr = coinNames;
       _portfolioViewModel.CoinWallets =  await _coinWalletService.GetUserWallet(id);

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
            portPortfolioViewModel.createPortfolioDto.UserId = Convert.ToInt32(HttpContext.Session.GetInt32("USERNAME"));
            await _portfolioService.AddPortfolio(portPortfolioViewModel.createPortfolioDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> BeginTransaction(CreateTransactionDto createTransactionDto)
        {
            var portfolioId =  Convert.ToInt32(HttpContext.Session.GetInt32("PortfolioId"));
            createTransactionDto.TransactionType = "Buy";
      var checkAmount=   await _transactionService.ManageTransaction(createTransactionDto, portfolioId);
      ViewBag.type = checkAmount;
         return RedirectToAction("Index");
        } 
        public async Task<IActionResult> SellTransaction(CreateTransactionDto createTransactionDto)
        {
            var portfolioId =  Convert.ToInt32(HttpContext.Session.GetInt32("PortfolioId"));
            createTransactionDto.TransactionType = "Sell";
            var checkAmount = await _transactionService.ManageTransaction(createTransactionDto, portfolioId);
         ViewBag.type= checkAmount;
            return RedirectToAction("Index");
        } 

    }
}
