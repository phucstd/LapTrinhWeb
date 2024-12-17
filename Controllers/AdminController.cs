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

        public IActionResult Products()
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
                return RedirectToAction(nameof(Products));
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
                return RedirectToAction(nameof(Products));
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
            return RedirectToAction(nameof(Products));

        }

        // Category Management - List Categories
        public IActionResult Categories()
        {
            var categories = _context.Categories.ToList();
            return View(categories);
        }

        // Create Category (GET)
        public IActionResult CreateCategory()
        {
            return View();
        }

        // Create Category (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                category.ImagePath ??= "content/images/t-shirts-img.jpg";
                _context.Categories.Add(category);
                _context.SaveChanges();
                return RedirectToAction(nameof(Categories));
            }
            return View(category);
        }

        // Edit Category (GET)
        public IActionResult EditCategory(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // Edit Category (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Update(category);
                _context.SaveChanges();
                return RedirectToAction(nameof(Categories));
            }
            return View(category);
        }

        // Delete Category (GET)
        public IActionResult DeleteCategory(int id)
        {
            var category = _context.Categories.Find(id);
            if (category != null)
            {
                var products = _context.Products.Where(_ => _.CategoryId.Equals(id));
                foreach (var item in products)
                {
                    _context.Products.Remove(item);
                }
                _context.SaveChanges();
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Categories));
        }
    }

}
