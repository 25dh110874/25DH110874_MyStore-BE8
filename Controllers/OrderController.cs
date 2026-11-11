using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _25DH110874_MyStore.Models;
using _25DH110874_MyStore.Models.ViewModel;

namespace _25DH110874_MyStore.Controllers
{
    public class OrderController : Controller
    {
        private MyStoreEntities db = new MyStoreEntities();
        // GET: Order
        public ActionResult Checkout()
        {
            var cart = Session["Cart"] as List<CartItem>;
            if (cart == null || !cart.Any())
            {
                return RedirectToAction("Index", "Cart");
            }
            var user = db.Users.SingleOrDefault(u => u.Username == User.Identity.Name);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var customer = db.Customers.SingleOrDefault(c => c.Username == user.Username);
            if (customer == null)
            {
                return RedirectToAction("Register", "Account");
            }
            var model = new CheckoutVM
            {
                CartItems = cart,
                CustomerID = customer.CustomerID,
                OrderDate = DateTime.Now,
                TotalAmount = cart.Sum(item => item.TotalPrice),
                PaymentStatus = "Pending",
                ShippingAddress = customer.CustomerAddress,
                DeliveryMethod = "Standard",
                PaymentMethod = "Cash on Delivery",
                Username = user.Username
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Checkout(CheckoutVM model)
        {
            if (ModelState.IsValid)
            {
                var cart = Session["Cart"] as List<CartItem>;
                if (cart == null || !cart.Any())
                {
                    return RedirectToAction("Index", "Home");
                }
                var user = db.Users.SingleOrDefault(u => u.Username == User.Identity.Name);
                if (user == null)
                {
                    return RedirectToAction("Login", "Account");
                }
                var customer = db.Customers.SingleOrDefault(c => c.Username == user.Username);
                if (customer == null)
                {
                    return RedirectToAction("Register", "Account");
                }
                if (model.PaymentMethod == "Paypal")
                {
                    // Redirect to PayPal payment page
                    return RedirectToAction("PaymentWithPayPal", "PayPal", model);
                }
                string paymentStatus = "Pending";
                switch (model.PaymentMethod)
                {
                    case "Cash on Delivery":
                        paymentStatus = "Cash on Delivery";
                        break;
                    case "Mua trước trả sau":
                        paymentStatus = "Trả góp";
                        break;
                    case "Paypal":
                        paymentStatus = "Thanh toán Paypal";
                        break;
                    default:
                        paymentStatus = "Chưa thanh toán";
                        break;
                }
                var order = new Order
                {
                    CustomerID = model.CustomerID,
                    OrderDate = model.OrderDate,
                    TotalAmount = model.TotalAmount,
                    PaymentStatus = paymentStatus,
                    ShippingAddress = model.ShippingAddress,
                    DeliveryMethod = model.DeliveryMethod,
                    PaymentMethod = model.PaymentMethod,
                    OrderDetails = cart.Select(item => new OrderDetail
                    {
                        ProductID = item.ProductID,
                        Quantity = item.Quantity,
                        UnitPrice = item.UnitPrice,
                        TotalPrice = item.TotalPrice
                    }).ToList()
                };
                db.Orders.Add(order);
                db.SaveChanges();
                Session["Cart"] = null;
                return RedirectToAction("OrderSuccess", new { id = order.OrderID });
            }
            return View(model);
        }
        public ActionResult OrderSuccess(int id)
        {
            var order = db.Orders.Find(id);
            return View(order);
        }
    }
}