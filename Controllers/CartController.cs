using _25DH110874_MyStore.Models;
using _25DH110874_MyStore.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _25DH110874_MyStore.Controllers
{
    public class CartController : Controller
    {
        private MyStoreEntities db = new MyStoreEntities();
        // GET: Cart
        private CartService GetCartService()
        {
            return new CartService(Session);
        }
        public ActionResult Index()
        {
            var cart = GetCartService().GetCart();
            return View(cart);
        }
        public ActionResult AddToCart(int id, int quantity = 1)
        {
            var product = db.Products.Find(id);
            if (product != null)
            {
                var cartService = GetCartService();
                cartService.GetCart().AddItem(product.ProductID, product.ProductImage, product.ProductName, product.ProductPrice, quantity, product.Category.CategoryName);
            }
            return RedirectToAction("Index");
        }
        public ActionResult RemoveFromCart(int id)
        {
            var cartService = GetCartService();
            cartService.GetCart().RemoveItem(id);
            return RedirectToAction("Index");
        }
        public ActionResult ClearCart()
        {
            var cartService = GetCartService();
            cartService.ClearCart();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult UpdateQuantity(int productId, int quantity)
        {
            var cartService = GetCartService();
            cartService.GetCart().UpdateQuantity(productId, quantity);
            return RedirectToAction("Index");
        }
    }
}