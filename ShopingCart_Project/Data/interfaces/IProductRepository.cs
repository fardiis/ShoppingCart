using ShopingCart_Project.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ShopingCart_Project.Data.interfaces
{
  public  interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
        IEnumerable<Product> SpecialProducts { get; }
        Product GetProductById(int productid);
    }
}
