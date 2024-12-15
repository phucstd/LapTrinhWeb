using Microsoft.AspNetCore.Mvc;
using TheWayShop.AppData;
using TheWayShop.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Identity;

namespace TheWayShop.Controllers
{
    public class ProductController : Controller
    {
        public const string CARTKEY = "cart";
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

        /// Thêm sản phẩm vào cart
        [Route("addcart/{productid:int}", Name ="addcart")]
        public IActionResult AddToCart([FromRoute] int productid)
        {

            var product = _db.Products.Where(p => p.Id == productid).FirstOrDefault();
            if (product == null)
                return NotFound("Không có sản phẩm");

            // Xử lý đưa vào Cart ...
            var cart = GetCartItems();
            var cartitem = cart.Find(p => p.product.Id == productid);
            if (cartitem != null)
            {
                // Đã tồn tại, tăng thêm 1
                cartitem.quantity++;
            }
            else
            {
                //  Thêm mới
                cart.Add(new CartItem() { quantity = 1, product = product });
            }

            // Lưu cart vào Session
            SaveCartSession(cart);
            // Chuyển đến trang hiện thị Cart
            return RedirectToAction(nameof(Cart));
        }
        /// xóa item trong cart
        [Route("/removecart/{productid:int}", Name = "removecart")]
        public IActionResult RemoveCart([FromRoute] int productid)
        {
            var cart = GetCartItems();
            var cartitem = cart.Find(p => p.product.Id == productid);
            if (cartitem != null)
            {
                // Đã tồn tại, tăng thêm 1
                cart.Remove(cartitem);
            }

            SaveCartSession(cart);
            return RedirectToAction(nameof(Cart));
        }

        /// Cập nhật
        [Route("/updatecart", Name = "updatecart")]
        [HttpPost]
        public IActionResult UpdateCart([FromBody] List<CartUpdateModel> cartUpdates)
        {
            var cart = GetCartItems();

            foreach (var update in cartUpdates)
            {
                var cartitem = cart.Find(p => p.product.Id == update.productid);
                if (cartitem != null)
                {
                    cartitem.quantity = update.quantity;
                }
            }

            SaveCartSession(cart);
            return Ok();
        }

        public class CartUpdateModel
        {
            public int productid { get; set; }
            public int quantity { get; set; }
        }



        // Hiện thị giỏ hàng
        [Route("/cart", Name = "cart")]
        public IActionResult Cart()
        {
            return View(GetCartItems());
        }

        [Route("/checkout", Name = "checkout")]
        public IActionResult CheckOut()
        {
            // Xử lý khi đặt hàng
            return View();
        }

        List<CartItem> GetCartItems()
        {

            var session = HttpContext.Session;
            string jsoncart = session.GetString(CARTKEY);
            if (jsoncart != null)
            {
                return JsonConvert.DeserializeObject<List<CartItem>>(jsoncart);
            }
            return new List<CartItem>();
        }

        // Xóa cart khỏi session
        void ClearCart()
        {
            var session = HttpContext.Session;
            session.Remove(CARTKEY);
        }

        // Lưu Cart (Danh sách CartItem) vào session
        void SaveCartSession(List<CartItem> ls)
        {
            var session = HttpContext.Session;
            string jsoncart = JsonConvert.SerializeObject(ls);
            session.SetString(CARTKEY, jsoncart);
        }

        public IActionResult PlaceOrder()
        {
            var cartItems = GetCartItems();
            if (cartItems.Count <= 0)
            {
                ViewBag.IsPurchaseSuccessful = false;
                return View();
            }

            Order order = new Order()
            {
                CreatedAt = DateTime.Now,
                Status = "Ordered",
                UserId = User.Identity?.Name
            };
            _db.Orders.Add(order);
            _db.SaveChanges();
            List<OrderProduct> orderProducts = new List<OrderProduct>();
            foreach (var product in cartItems)
            {
                orderProducts.Add(new OrderProduct()
                {
                    OrderId = order.Id,
                    ProductId = product.product.Id,
                    Quantity = product.quantity,
                    Price = product.product.Price
                });
            }
            // Add the item to the database
            
            _db.OrderProducts.AddRange(orderProducts);
            _db.SaveChanges(); // Save changes to persist the new item.
            ViewBag.IsPurchaseSuccessful = true;
            ClearCart();
            return View(); // Redirect back to the Index page.
        }
    }
}
