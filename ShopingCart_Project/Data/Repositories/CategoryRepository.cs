using ShopingCart_Project.Data.interfaces;
using ShopingCart_Project.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ShopingCart_Project.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext appDbContext;
        public CategoryRepository(AppDbContext _appDbContext)
        {
            appDbContext = _appDbContext;
        }
        public IEnumerable<Category> Categories => appDbContext.Categories;
    }
}
