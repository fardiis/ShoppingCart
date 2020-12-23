using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopingCart_Project.Data.interfaces;
using ShopingCart_Project.Data.Models;

namespace ShopingCart_Project.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository orderRepository;
        private readonly ShoppingCart shoppingCart;
        public OrderController(IOrderRepository _orderRepository, ShoppingCart _shoppingCart)
        {
            orderRepository = _orderRepository;
            shoppingCart = _shoppingCart;

        }
      
        public IActionResult CheckOut()
        {
            var items = shoppingCart.GetShoppingCartItems();
            shoppingCart.ShoppingCartItems = items;
            if (shoppingCart.ShoppingCartItems.Count == 0)
            {
                TempData["Message"] = "سبد خرید خالی است لطفا یک یا چند محصول را به سبد خریدتان اضافه نمایید";
                @TempData["Style"] = "alert alert-danger";
                return RedirectToAction("Index", "ShoppingCart");
            }
            return View();
        }
        [HttpPost]
      
        public IActionResult CheckOut(Orders order)
        {
            var items = shoppingCart.GetShoppingCartItems();
            shoppingCart.ShoppingCartItems = items;
            if (shoppingCart.ShoppingCartItems.Count==0)
            {
                ModelState.AddModelError("", "سبد خرید خالی است");
                return RedirectToAction("Index", "ShoppingCart");
            }
            if (ModelState.IsValid)
            {
                orderRepository.CreateOrder(order);
                shoppingCart.ClearCart();
                return RedirectToAction("CheckOutComplet");

            }
            return View(order);
        }

  
        public IActionResult CheckOutComplet()
        {
            ViewBag.Message = "با تشکر از خرید شما";
            return View();
        }
    }
}
