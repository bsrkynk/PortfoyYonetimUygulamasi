using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PortfoyYonetimUygulamasi.MVC.Filters;

namespace PortfoyYonetimUygulamasi.MVC.Controllers
{
    [UserFilter]
    public class PortfolioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
