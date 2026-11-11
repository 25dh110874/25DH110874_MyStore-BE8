using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _25DH110874_MyStore.Models.ViewModel
{
    public class CartItem
    {
        public int ProductID { get; set; }
        public string ProductImage { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice => ProductPrice * Quantity;
        public decimal UnitPrice => ProductPrice;
    }
}