using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopingCart_Project.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace ShopingCart_Project.Data
{
    public class DbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.GetRequiredService<IServiceProvider>()
                .CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();
                if (!context.Categories.Any())
                {
                    context.Categories.AddRange(Categories.Select(c => c.Value));
                }
                if (!context.Products.Any())
                {
                    context.AddRange(
                           new Product
                           {
                               ProductName ="ایفون 10",
                               Price = 4000000,
                               ShortDescription = "بهترین محصول",
                               LongDescription = "مشخصات گوشی : 256 گیگ",
                               IsSpecialProduct = false,
                               Category = Categories["موبایل"],
                               ImagThumbnailUrl = "https://dkstatics-public.digikala.com/digikala-products/be7a0e9bf7866759fa3cea7648b149f589a01040_1607433891.jpg",
                               ImagUrl = "https://dkstatics-public.digikala.com/digikala-reviews/1ce7ecc163fbfddff8e57be2beb88364353416c0_1606767873.jpg",

                           },
                         
                        new Product
                        {
                             
                            ProductName = "ال جي مدل Q6",
                            Price = 2500000,
                            ShortDescription = "بهترین گوشی ال جی",
                            LongDescription = "مشخصات گوشی : 64 گیگ",
                            IsSpecialProduct = true,
                            Category = Categories["موبایل"],
                            ImagThumbnailUrl = "https://dkstatics-public.digikala.com/digikala-products/119637598.jpg",
                            ImagUrl = "https://dkstatics-public.digikala.com/digikala-reviews/101473177.jpg",
                        },
                         new Product
                         {
                             ProductName = "موبايل هوآوي",
                             Price = 1400000,
                             ShortDescription = "گوشي موبايل هوآوي مدل",
                             LongDescription = "گوشي موبايل هوآوي مدل Mate 10 Pro BLA-L29 دو سيم‌ کارت",
                             IsSpecialProduct = true,
                             Category = Categories["موبایل"],
                             ImagThumbnailUrl = "https://dkstatics-public.digikala.com/digikala-products/121811757.jpg",
                             ImagUrl = "https://dkstatics-public.digikala.com/digikala-reviews/8adcd9d0565e996d1ace5ea8642479f43ea938bd_1597484874.jpg",

                         }, new Product
                         {
                             ProductName = "لب تاپ ایسوس",
                             Price = 3800000,
                             ShortDescription = "بهترین لب تاپ",
                             LongDescription = "بهترین لب تاپ در جهان",
                             IsSpecialProduct = false,
                             Category = Categories["لب تاپ"],
                             ImagThumbnailUrl = "https://dkstatics-public.digikala.com/digikala-products/9388b2edf2fc54b9b6d66a50729b2324915a6572_1602486024.jpg",
                             ImagUrl = "https://dkstatics-public.digikala.com/digikala-products/9388b2edf2fc54b9b6d66a50729b2324915a6572_1602486024.jpg",

                         }, new Product
                         {
                             ProductName = "لپ تاپ ام اس ای",
                             Price = 18000000,
                             ShortDescription = "لپ تاپ 13 اینچی ام اس ای",
                             LongDescription = "بهترین لب تاپ ام اس ای",
                             IsSpecialProduct = true,
                             Category = Categories["لب تاپ"],
                             ImagThumbnailUrl = "https://dkstatics-public.digikala.com/digikala-products/e9fe7050c6dbffc973ef805f50e063799b316648_1606130972.jpg",
                             ImagUrl = "https://dkstatics-public.digikala.com/digikala-products/e9fe7050c6dbffc973ef805f50e063799b316648_1606130972.jpg",


                         });
                }
                context.SaveChanges();
            }
        }
        private static Dictionary<string, Category> categories;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (categories==null)
                {
                    var generateList = new Category[]
                    {
                        new Category{CategoryName="موبایل",Description="فروش انواع لپ تاپ"},
                         new Category{CategoryName="لب تاپ",Description="فروش انواع لپ تاپ"}
                    };
                    categories = new Dictionary<string, Category>();
                    foreach (Category item in generateList)
                    {
                        categories.Add(item.CategoryName, item);
                    }
                }
                return categories;
            }
        }
    }
}
