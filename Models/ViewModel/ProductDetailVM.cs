using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using System.Security.Permissions;

namespace _25DH110874_MyStore.Models.ViewModel
{
    public class ProductDetailVM
    {
        public Product product { get; set; }
        public int quantity { get; set; } = 1;
        public decimal estimatedValue => quantity * product.ProductPrice;
        public int PageNumber { get; set; }
        public int PageSize { get; set; } = 3;
        public IPagedList<Product> RelatedProducts { get; set; }
        public IPagedList<Product> TopProducts { get; set; }
    }
}