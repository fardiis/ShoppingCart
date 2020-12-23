using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopingCart_Project.Data.interfaces;
using ShopingCart_Project.Data.Models;
using ShopingCart_Project.Data.Repositories;
using ShopingCart_Project.ViewModels;

namespace ShopingCart_Project.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IProductRepository productRepository;
        private readonly ShoppingCart shoppingCart;
        public ShoppingCartController(IProductRepository _productRepository, ShoppingCart _shoppingCart)
        {
            productRepository = _productRepository;
            shoppingCart = _shoppingCart;
        }
        public ViewResult Index()
        {
            var items = shoppingCart.GetShoppingCartItems();
            shoppingCart.ShoppingCartItems = items;
            var ShopCart_VM = new ShoppingCartViewModel()
            {
                shoppingCart = shoppingCart,
                ShoppingCartTotal = shoppingCart.GetShoppingCartTotal()
            };
            return View(ShopCart_VM);
        }
        public RedirectToActionResult AddToShoppingCart(int productId)
        {
            var selectedProduct = productRepository.Products.FirstOrDefault(c => c.ProductId == productId);
            if(selectedProduct != null)
            {
                shoppingCart.AddToCart(selectedProduct, 1);
            }
            return RedirectToAction("Index","Home");
        }
        public RedirectToActionResult RemoveFromShoppingCart(int productId)
        {
            var selectedProduct = productRepository.Products.FirstOrDefault(c => c.ProductId == productId);
            if (selectedProduct!=null)
            {
                shoppingCart.RemoveFromCart(selectedProduct);
            }
            return RedirectToAction("Index");
        }
        public IActionResult CheckExistshoppingCart()
        {
            var items = shoppingCart.GetShoppingCartItems();
            if (items.Count>0)
            {
              
                return RedirectToAction("Index", "ShoppingCart");
            }
            else
            {
                TempData["Message"] = "سبد خرید شما خالی است";
                TempData["Style"] = "alert alert-danger ";
                return RedirectToActionPermanent("Index", "ShoppingCart");
            }

        }
        public IActionResult ClearShoppingCart()
        {
            var items = shoppingCart.GetShoppingCartItems();
            shoppingCart.ShoppingCartItems = items;
            if (shoppingCart.ShoppingCartItems.Count >= 1)
            {
                shoppingCart.ClearCart();
                TempData["Message"] = "سبد خرید با موفقیت خالی شد";
                TempData["Style"] = "alert alert-success ";
                return RedirectToAction("Index", "ShoppingCart");
            }
            else
            {
                TempData["Message"] = "محصولی در سبد خرید وجودندارد";
                TempData["Style"] = "alert alert-danger ";
                return RedirectToAction("Index", "ShoppingCart");
            }


        }
    }
    
}
