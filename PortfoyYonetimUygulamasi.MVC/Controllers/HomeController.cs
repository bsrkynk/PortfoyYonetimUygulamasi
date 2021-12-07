using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PortfoyYonetimUygulamasi.Entity.User;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace PortfoyYonetimUygulamasi.MVC.Controllers
{
    [RoutePrefix("/api/PortfoyYonetimSitesi")]
    public class HomeController : Controller
    {
        [HttpPost]
        [Route("/Home")]
        public IActionResult Index()
        {
            var client = new RestClient("https://api.binance.com/api/v3/ticker/24hr");
            var request = new RestRequest(Method.GET);

            IRestResponse response = client.Execute(request);
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.NullValueHandling = NullValueHandling.Ignore;

            var myJson = JsonConvert.DeserializeObject(response.Content, settings);
            JArray jsonArray = JArray.Parse(response.Content);

            List<string> childTokens = new List<string>();

            foreach (var childToken in jsonArray.Children())
            {
                childTokens.Add(childToken.ToString());
            }

            List<_24HourExchange> _24HourExchangeList = new List<_24HourExchange>();

            foreach (var x in childTokens)
            {
                _24HourExchangeList.Add(JsonConvert.DeserializeObject<_24HourExchange>(x));
            }

            return View(_24HourExchangeList);
        }
    }
}
