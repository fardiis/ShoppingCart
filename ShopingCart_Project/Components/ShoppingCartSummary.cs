using Microsoft.AspNetCore.Mvc;
using ShopingCart_Project.Data.Models;
using ShopingCart_Project.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopingCart_Project.Components
{
  
    public class ShoppingCartSummary:ViewComponent
    {
        private readonly ShoppingCart shoppingCart;
        public ShoppingCartSummary(ShoppingCart _shoppingCart)
        {
            shoppingCart = _shoppingCart;
        }
        public IViewComponentResult Invoke()
        {
            var items = shoppingCart.GetShoppingCartItems();
            shoppingCart.ShoppingCartItems = items;
            var shoppingCartViewModel = new ShoppingCartViewModel()
            {
                shoppingCart=shoppingCart,
                ShoppingCartTotal=shoppingCart.GetShoppingCartTotal()

            };
            return View(shoppingCartViewModel);
        }
    }
}
