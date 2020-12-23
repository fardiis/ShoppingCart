using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopingCart_Project.Data.interfaces;
using ShopingCart_Project.ViewModels;

namespace ShopingCart_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepository productRepository;
        public HomeController(IProductRepository _productRepository)
        {
            productRepository = _productRepository;
        }
        public ViewResult Index()
        {
            var homeViewModel=new HomeViewModel()
            {
             SpecialProducts=productRepository.SpecialProducts
            };
            return View(homeViewModel);
        }
    }
}
