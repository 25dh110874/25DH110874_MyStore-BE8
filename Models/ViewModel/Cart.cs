using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _25DH110874_MyStore.Models.ViewModel
{
    public class Cart
    {
        private List<CartItem> items;

        public Cart()
        {
            items = new List<CartItem>();
        }

        public void AddItem(int productID, string productImage, string productName, decimal productPrice, int quantity, string category)
        {
            var existingItem = items.FirstOrDefault(i => i.ProductID == productID);
            if (existingItem == null)
            {
                items.Add(new CartItem
                {
                    ProductID = productID,
                    ProductImage = productImage,
                    ProductName = productName,
                    ProductPrice = productPrice,
                    Quantity = quantity
                });
            }
            else
            {
                existingItem.Quantity += quantity;
            }
        }
        public void RemoveItem(int productID)
        {
            items.RemoveAll(i => i.ProductID == productID);
        }
        public decimal TotalValue() {  return items.Sum(i => i.TotalPrice); }

        public void Clear() { items.Clear(); }

        public void UpdateQuantity(int productID, int quantity)
        {
            var existingItem = items.FirstOrDefault(i => i.ProductID == productID);
            if (existingItem != null)
            {
                existingItem.Quantity = quantity;
            }
        }

        public IEnumerable<CartItem> Items => items;
    }
}