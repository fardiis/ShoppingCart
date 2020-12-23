using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ShopingCart_Project.Data.Models;
using ShopingCart_Project.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ShopingCart_Project.Data.Models
{
    public class ShoppingCart
    {
        private readonly AppDbContext appDbContext;
        private readonly IHttpContextAccessor httpContextAccessor;
        public ShoppingCart(AppDbContext _appDbContext)
        {
            appDbContext = _appDbContext;
        }
        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDbContext>();
            string cartid = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartid);
            return new ShoppingCart(context) { ShoppingCartId = cartid };

        }
        public void AddToCart(Product product,int amount)
        {
            var shoppingCartItem = appDbContext.ShoppingCartItems.SingleOrDefault(
              s => s.ShoppingCartId == ShoppingCartId && s.Products.ProductId == product.ProductId);
            if(shoppingCartItem==null)
            {
                shoppingCartItem = new ShoppingCartItem()
                {
                    Amount = 1,
                ShoppingCartId=ShoppingCartId,
                Products=product
                };
                appDbContext.ShoppingCartItems.Add(shoppingCartItem);

            }
            else
            {
                shoppingCartItem.Amount++;
            }
            appDbContext.SaveChanges();
        }
        public int RemoveFromCart(Product product)
        {
            var shoppingCartItem = appDbContext.ShoppingCartItems.SingleOrDefault(
             s => s.ShoppingCartId == ShoppingCartId && s.Products.ProductId == product.ProductId);
            int localAmount = 0;

            if (shoppingCartItem !=null)
            {
                if(shoppingCartItem.Amount>1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    appDbContext.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }
            appDbContext.SaveChanges();
            return localAmount;
        }
        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ??
                (ShoppingCartItems = appDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                .Include(c => c.Products).ToList());
        }
        public void ClearCart()
        {
            var cartItems = appDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId);
            if (cartItems != null)
            {
                appDbContext.ShoppingCartItems.RemoveRange(cartItems);
                appDbContext.SaveChanges();
            }
        }
        //جمع قیمت محصولات
        public decimal GetShoppingCartTotal()
        {
            var total = appDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                                                      .Select(c => c.Products.Price * c.Amount).Sum();
            return total;

        }
    }
}
