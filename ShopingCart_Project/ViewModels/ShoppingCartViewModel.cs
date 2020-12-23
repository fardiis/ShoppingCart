using ShopingCart_Project.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopingCart_Project.ViewModels
{
    public class ShoppingCartViewModel
    {
        public  ShoppingCart shoppingCart { get; set; }
        public decimal ShoppingCartTotal { get; set; }
    }
}
