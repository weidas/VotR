using Microsoft.AspNet.Mvc;
using VotR.Services.Interfaces;

namespace VotR.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IExternalService _externalService;

        public HomeController(IExternalService externalService)
        {
            _externalService = externalService;
        }

        public IActionResult Index()
        {
            WcfService1 x = new WcfService1();

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
    }
}
