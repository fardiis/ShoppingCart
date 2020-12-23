using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopingCart_Project.Data.interfaces;
using ShopingCart_Project.Data.Models;
using ShopingCart_Project.ViewModels;

namespace ShopingCart_Project.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository productRepository;
        private readonly ICategoryRepository categoryRepository;
        public ProductController(IProductRepository _productRepository,ICategoryRepository _categoryRepository)
        {
            productRepository = _productRepository;
            categoryRepository = _categoryRepository;
        }
        public IActionResult List(string category)
        {
            string _category = category;
            IEnumerable<Product> products;
            string currentCategory = string.Empty;
            if (string.IsNullOrEmpty(category))
            {
                products = productRepository.Products.OrderBy(c => c.ProductId);
                currentCategory = "همه محصولات";
            }
            else
            {
                if (string.Equals("موبایل", _category, StringComparison.OrdinalIgnoreCase))
                {
                    products = productRepository.Products.Where(c => c.Category.CategoryName.Equals("موبایل")).OrderBy(c => c.ProductName);

                }
                else
                    products = productRepository.Products.Where(c => c.Category.CategoryName.Equals("لب تاپ")).OrderBy(c => c.ProductName);
                currentCategory = _category;
            }
                var ProductListViewModel = new ProductListViewModel()
                {
                    Products = products
                };
            
                return View(ProductListViewModel);
              
            
            //ProductListViewModel vm = new ProductListViewModel();
            //vm.Products = productRepository.Products;
            //vm.CurrentCategory = "All Category";
            //return View(vm);
        } 
        public IActionResult Details(int productId)
        {
            var selected = productRepository.GetProductById(productId);
            return View(selected);
        }
    }
}
