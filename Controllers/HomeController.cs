using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TheWayShop.AppData;
using TheWayShop.Models;

namespace TheWayShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDBContext _db;

        public HomeController(ILogger<HomeController> logger, AppDBContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            var productsId1 = _db.Products.Where(product => product.CategoryId == 1).ToList();
            var productsId2 = _db.Products.Where(product => product.CategoryId == 2).ToList();
            ViewData["productsId1"] = productsId1;
            ViewData["productsId2"] = productsId2;
            return View();
        }

        public IActionResult Privacy()
        {
           var products = _db.Products.ToList();
            return View(products);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
