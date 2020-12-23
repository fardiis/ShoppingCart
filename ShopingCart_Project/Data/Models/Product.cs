using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopingCart_Project.Data.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public decimal Price { get; set; }
        public string ImagUrl { get; set; }
        public string ImagThumbnailUrl { get; set; }
        public bool IsSpecialProduct { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

    }
}
