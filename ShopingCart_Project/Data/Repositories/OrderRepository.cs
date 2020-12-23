using ShopingCart_Project.Data.interfaces;
using ShopingCart_Project.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopingCart_Project.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ShoppingCart shoppingCart;
        private readonly AppDbContext appDbContext;
        public OrderRepository(AppDbContext _appDbContext, ShoppingCart _shoppingCart)
        {
            appDbContext = _appDbContext;
            shoppingCart = _shoppingCart;
        }
        public void CreateOrder(Orders orders)
        {
            orders.OrderTime = DateTime.Now;
            appDbContext.Orders.Add(orders);
            var shoppingCartItems = shoppingCart.ShoppingCartItems;
            foreach (var item in shoppingCartItems)
            {
                var orderDetail = new OrderDetails()
                {
                    Amount = item.Amount,
                    ProductId = item.Products.ProductId,
                    Price = item.Products.Price,
                    OrderId = orders.OrderId
                };
                appDbContext.OrderDetails.Add(orderDetail);
            
            }
            appDbContext.SaveChanges();
        }
    }
}
