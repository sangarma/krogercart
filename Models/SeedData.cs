using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using krogercart.Models;

namespace krogercart.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AppDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
                
                if (context.Products.Any())
                {
                    return; 
                }

                
                var products = new Product[]
                {
                    new Product { Name = "Apple", Description = "Fresh red apple", Price = 0.50M, ImageURL = "/img/productimage" },
                    new Product { Name = "Banana", Description = "Ripe yellow banana", Price = 0.30M, ImageURL = "/img/productimage" },
                    new Product { Name = "Orange", Description = "Citrus orange", Price = 0.60M, ImageURL = "/img/productimage" },
                    new Product { Name = "Grapes", Description = "Seedless green grapes", Price = 2.00M, ImageURL = "/img/productimage" },
                    new Product { Name = "Strawberries", Description = "Fresh strawberries", Price = 2.50M, ImageURL = "/img/productimage" },
                    new Product { Name = "Blueberries", Description = "Juicy blueberries", Price = 3.00M, ImageURL = "/img/productimage" },
                    new Product { Name = "Raspberries", Description = "Tart raspberries", Price = 3.20M, ImageURL = "/img/productimage" },
                    new Product { Name = "Cherries", Description = "Sweet cherries", Price = 4.00M, ImageURL = "/img/productimage" },
                    new Product { Name = "Pineapple", Description = "Tropical pineapple", Price = 2.70M, ImageURL = "/img/productimage" },
                    new Product { Name = "Mango", Description = "Sweet and juicy mango", Price = 1.50M, ImageURL = "/img/productimage" },
                    new Product { Name = "Bread", Description = "Whole wheat bread", Price = 2.00M, ImageURL = "/img/productimage" },
                    new Product { Name = "Milk", Description = "1 gallon of fresh milk", Price = 3.00M, ImageURL = "/img/productimage" },
                    new Product { Name = "Cheese", Description = "Aged cheddar cheese", Price = 4.50M, ImageURL = "/img/productimage" },
                    new Product { Name = "Yogurt", Description = "Plain Greek yogurt", Price = 1.20M, ImageURL = "/img/productimage" },
                    new Product { Name = "Eggs", Description = "Dozen large eggs", Price = 2.50M, ImageURL = "/img/productimage" },
                    new Product { Name = "Chicken Breast", Description = "Boneless chicken breast", Price = 5.00M, ImageURL = "/img/productimage" },
                    new Product { Name = "Ground Beef", Description = "Lean ground beef", Price = 6.50M, ImageURL = "/img/productimage" },
                    new Product { Name = "Salmon", Description = "Fresh Atlantic salmon", Price = 8.00M, ImageURL = "/img/productimage" },
                    new Product { Name = "Shrimp", Description = "Peeled and deveined shrimp", Price = 9.00M, ImageURL = "/img/productimage" },
                    new Product { Name = "Butter", Description = "Salted butter", Price = 2.20M, ImageURL = "/img/productimage" },
                    new Product { Name = "Almonds", Description = "Raw almonds", Price = 5.00M, ImageURL = "/img/productimage" },
                    new Product { Name = "Walnuts", Description = "Shelled walnuts", Price = 5.50M, ImageURL = "/img/productimage" },
                    new Product { Name = "Spinach", Description = "Fresh spinach", Price = 1.00M, ImageURL = "/img/productimage" },
                    new Product { Name = "Broccoli", Description = "Green broccoli florets", Price = 1.50M, ImageURL = "/img/productimage" },
                    new Product { Name = "Carrots", Description = "Organic carrots", Price = 1.20M, ImageURL = "/img/productimage" },
                    new Product { Name = "Potatoes", Description = "Russet potatoes", Price = 1.00M, ImageURL = "/img/productimage" },
                    new Product { Name = "Tomatoes", Description = "Vine-ripened tomatoes", Price = 1.80M, ImageURL = "/img/productimage" },
                    new Product { Name = "Onions", Description = "Yellow onions", Price = 1.00M, ImageURL = "/img/productimage" },
                    new Product { Name = "Garlic", Description = "Fresh garlic bulbs", Price = 0.90M, ImageURL = "/img/productimage" },
                    new Product { Name = "Olive Oil", Description = "Extra virgin olive oil", Price = 6.00M, ImageURL = "/img/productimage" }
                };

                context.Products.AddRange(products);
                context.SaveChanges();

                
                var cart = new Cart
                {
                    CreationDate = DateTime.UtcNow
                };
                context.Carts.Add(cart);
                context.SaveChanges();

                
                var cartId = cart.CartID;
                var productList = context.Products.Take(30).ToList();

                
                var random = new Random();
                var chosenProducts = productList.OrderBy(x => random.Next()).Take(5).ToArray();

                var productCarts = new ProductCart[]
                {
                    new ProductCart { CartID = cartId, ProductID = chosenProducts[0].ProductID, Quantity = 2 },
                    new ProductCart { CartID = cartId, ProductID = chosenProducts[1].ProductID, Quantity = 3 },
                    new ProductCart { CartID = cartId, ProductID = chosenProducts[2].ProductID, Quantity = 1 },
                    new ProductCart { CartID = cartId, ProductID = chosenProducts[3].ProductID, Quantity = 4 },
                    new ProductCart { CartID = cartId, ProductID = chosenProducts[4].ProductID, Quantity = 2 }
                };

                context.ProductCarts.AddRange(productCarts);
                context.SaveChanges();
            }
        }
    }
}