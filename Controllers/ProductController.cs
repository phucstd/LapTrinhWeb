using Microsoft.AspNetCore.Mvc;
using TheWayShop.AppData;
using TheWayShop.Models;
using System.Linq;

namespace TheWayShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDBContext _db;
        public ProductController(AppDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Detail(int id)
        {
            Product p = _db.Products.Where(_ => _.Id == id).FirstOrDefault();
          
            return View(p);
        }
        public IActionResult ProductList(int id)
        {
            List<Product> list = _db.Products.Where(_ => _.CategoryId == id).ToList();

            return View(list);
        }
    }
}
