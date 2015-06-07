using Microsoft.AspNet.Mvc;
using Microsoft.Framework.Caching.Memory;
using System.Collections.Generic;
using VotR.Services.DataContracts;
using VotR.Services.Interfaces;
using System;

namespace VotR.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IExternalService _externalService;
        private readonly IBeerService _beerService;
        private readonly IMemoryCache _cache;

        public HomeController(IExternalService externalService, IBeerService beerService, IMemoryCache cache)
        {
            _externalService = externalService;
            _beerService = beerService;
            _cache = cache;
        }

        public IActionResult Index()
        {

            return View();
        }
        
        public IActionResult Error()
        {
            return View("~/Views/Shared/Error.cshtml");
        }

        public IActionResult SyncSystembolaget()
        {
            
            var articles =_externalService.GetArticlesFromSystemBolaget("http://www.systembolaget.se/api/assortment/products/xml");
            _cache.Set<List<SystemBolagetArticle>>("articles", articles);

            return View("Index");
        }

        public IActionResult GetBeer()
        {
            //TODO Fixa konstantnamn för cachenyckel
            var articles = _cache.GetOrSet<List<SystemBolagetArticle>>("articles", context =>
            {
                context.SetSlidingExpiration(TimeSpan.FromSeconds(15));
                return _externalService.GetArticlesFromSystemBolaget("http://www.systembolaget.se/api/assortment/products/xml");
            });
            return View("Index");
        }
    }
}
