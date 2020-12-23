using Microsoft.EntityFrameworkCore;
using ShopingCart_Project.Data.interfaces;
using ShopingCart_Project.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopingCart_Project.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext appDbContext;
        public ProductRepository(AppDbContext _appDbContext)
        {
            appDbContext = _appDbContext;
        }
        public IEnumerable<Product> Products => appDbContext.Products.Include(c => c.Category);

        public IEnumerable<Product> SpecialProducts => appDbContext.Products.Where(c => c.IsSpecialProduct).Include(c => c.Category);


        public Product GetProductById(int productid) => appDbContext.Products.FirstOrDefault(c => c.ProductId == productid);
        
    }
}
