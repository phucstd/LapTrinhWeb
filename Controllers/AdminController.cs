using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using TheWayShop.AppData; 
using TheWayShop.Models; 

namespace TheWayShop.Controllers
{
   
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly AppDBContext _context;

        public AdminController(AppDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.Categories = _context.Categories.ToDictionary(c => c.Id, c => c.Name);
            var products = _context.Products.ToList();
            return View(products);
        }

        // GET: Admin/CreateProduct
        public IActionResult CreateProduct()
        {
            ViewBag.Categories = _context.Categories.ToList(); // Assuming you have a Categories table
            return View();
        }

        // POST: Admin/CreateProduct
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Categories = _context.Categories.ToList();
            return View(product);
        }

        // GET: Admin/EditProduct/5
        public IActionResult EditProduct(int? id)
        {
            if (id == null) return NotFound();

            var product = _context.Products.Find(id);
            if (product == null) return NotFound();

            ViewBag.Categories = _context.Categories.ToList();
            return View(product);
        }

        // POST: Admin/EditProduct/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditProduct(int id, Product product)
        {
            if (id != product.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Categories = _context.Categories.ToList();
            return View(product);
        }

        // GET: Admin/DeleteProduct/5
        public IActionResult DeleteProduct(int? id)
        {
            if (id == null) return NotFound();

            var product = _context.Products.Find(id);
            if (product == null) return NotFound();
            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
    }

}
