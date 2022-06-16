using ConvertValute.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ConvertValute.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            CurrencyGetValute currencyGet = new CurrencyGetValute();
            CurrencyConverter currencyConverter = new CurrencyConverter();
            currencyConverter.USD = currencyGet.Get("usd", DateTime.Now);
            currencyConverter.EUR = currencyGet.Get("eur", DateTime.Now);
            currencyConverter.RUB = currencyGet.Get("rub", DateTime.Now);

            CurrencyState.prev.USD = currencyGet.Get("usd", DateTime.Now.AddDays(-1));
            CurrencyState.prev.RUB = currencyGet.Get("rub", DateTime.Now.AddDays(-1));
            CurrencyState.prev.EUR = currencyGet.Get("eur", DateTime.Now.AddDays(-1));
            //if (CurrencyState.current == null || CurrencyState.current.RUB == null || CurrencyState.current.USD == null || CurrencyState.current.RUB == null)
            //{
            //    CurrencyState.current = model;
            //}
            //if (CurrencyState.prev == null || CurrencyState.prev.RUB == null || CurrencyState.prev.USD == null || CurrencyState.prev.RUB == null)
            //{
            //    CurrencyState.prev = CurrencyState.current;
            //}


            //if (model.EUR.buy_value != CurrencyState.current.EUR.buy_value || model.EUR.sell_value != CurrencyState.current.EUR.sell_value || model.EUR.nbt_value != CurrencyState.current.EUR.nbt_value)
            //{
            //    CurrencyState.prev.EUR = CurrencyState.current.EUR;
            //    CurrencyState.current.EUR = model.EUR;
            //}

            //if (model.USD.buy_value != CurrencyState.current.USD.buy_value || model.USD.sell_value != CurrencyState.current.USD.sell_value || model.USD.nbt_value != CurrencyState.current.USD.nbt_value)
            //{
            //    CurrencyState.prev.USD = CurrencyState.current.USD;
            //    CurrencyState.current.USD = model.USD;
            //}

            //if (model.RUB.buy_value != CurrencyState.current.RUB.buy_value || model.RUB.sell_value != CurrencyState.current.RUB.sell_value || model.RUB.nbt_value != CurrencyState.current.RUB.nbt_value)
            //{
            //    CurrencyState.prev.RUB = CurrencyState.current.RUB;
            //    CurrencyState.current.RUB = model.RUB;
            //}


            return View(currencyConverter);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
