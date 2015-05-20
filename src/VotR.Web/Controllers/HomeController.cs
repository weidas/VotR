using Microsoft.AspNet.Mvc;
using VotR.Services.Interfaces;

namespace VotR.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IExternalService _externalService;
        private readonly IBeerService _beerService;

        public HomeController(IExternalService externalService, IBeerService beerService)
        {
            _externalService = externalService;
            _beerService = beerService;
        }

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View("~/Views/Shared/Error.cshtml");
        }

        public IActionResult SyncSystembolaget()
        {
            var x =_externalService.GetArticlesFromSystemBolaget("http://www.systembolaget.se/api/assortment/products/xml");

            return View("Index");
        }

        public IActionResult GetBeer()
        {
            var b = _beerService.GetAll();

            return View("Index");
        }
    }
}
