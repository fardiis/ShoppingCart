using Microsoft.AspNetCore.Mvc;
using ShopingCart_Project.Data.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopingCart_Project.Components
{
    public class CategoryMenu:ViewComponent
    {
        private readonly ICategoryRepository categoryRepository;
        public CategoryMenu(ICategoryRepository _categoryRepository)
        {
            categoryRepository = _categoryRepository;
        }
        public IViewComponentResult Invoke()
        {
            var categories = categoryRepository.Categories.OrderBy(c => c.CategoryName);
            return View(categories);
        }
    }
}
