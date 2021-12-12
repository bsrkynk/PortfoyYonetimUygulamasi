using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PortfoyYonetimUygulamasi.Host.Controllers.User;
using PortfoyYonetimUygulamasi.Entity.User;

namespace PortfoyYonetimUygulamasi.MVC.Controllers
{

    public class HomeController:Controller
    {
        public IActionResult Index()
        {
            List<_24HourExchange> _24HourExchangeList = Home.HomeIndex();
            return View(_24HourExchangeList);
        }

    }
}
