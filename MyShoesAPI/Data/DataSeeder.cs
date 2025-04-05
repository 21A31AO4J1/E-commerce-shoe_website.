using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyShoesAPI.Models;

namespace MyShoesAPI.Data
{
    public static class DataSeeder
    {
        public static async Task SeedProducts(ApplicationDbContext context)
        {
            // Check if products already exist
            if (await context.Products.AnyAsync())
            {
                return; // Database has already been seeded
            }

            // Create sample products
            var products = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "Nike Air Max",
                    Title = "Classic Nike Air Max",
                    Description = "Classic Nike Air Max sneakers with comfortable cushioning",
                    Price = 129.99m,
                    StockQuantity = 50,
                    Category = "Sneakers",
                    Brand = "Nike",
                    Size = "42",
                    Color = "Black",
                    ImageUrl = "https://images.unsplash.com/photo-1542291026-7eec264c27ff?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=2070&q=80",
                    CreatedAt = DateTime.UtcNow
                },
                new Product
                {
                    Id = 2,
                    Name = "Adidas Ultraboost",
                    Title = "Premium Adidas Ultraboost",
                    Description = "Premium Adidas Ultraboost running shoes with responsive cushioning",
                    Price = 179.99m,
                    StockQuantity = 30,
                    Category = "Running",
                    Brand = "Adidas",
                    Size = "43",
                    Color = "White",
                    ImageUrl = "https://images.unsplash.com/photo-1608231387042-66d1773070a5?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1974&q=80",
                    CreatedAt = DateTime.UtcNow
                },
                new Product
                {
                    Id = 3,
                    Name = "Puma RS-X",
                    Title = "Stylish Puma RS-X",
                    Description = "Stylish Puma RS-X sneakers with chunky design",
                    Price = 99.99m,
                    StockQuantity = 25,
                    Category = "Lifestyle",
                    Brand = "Puma",
                    Size = "41",
                    Color = "Blue",
                    ImageUrl = "https://images.unsplash.com/photo-1600185365483-26d7a4cc7519?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=2070&q=80",
                    CreatedAt = DateTime.UtcNow
                },
                new Product
                {
                    Id = 4,
                    Name = "New Balance 574",
                    Title = "Classic New Balance 574",
                    Description = "Classic New Balance 574 sneakers with timeless design",
                    Price = 89.99m,
                    StockQuantity = 40,
                    Category = "Lifestyle",
                    Brand = "New Balance",
                    Size = "42",
                    Color = "Gray",
                    ImageUrl = "https://images.unsplash.com/photo-1549298916-b41d501d3772?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=2012&q=80",
                    CreatedAt = DateTime.UtcNow
                },
                new Product
                {
                    Id = 5,
                    Name = "Reebok Classic",
                    Title = "Iconic Reebok Classic",
                    Description = "Iconic Reebok Classic sneakers with leather upper",
                    Price = 79.99m,
                    StockQuantity = 35,
                    Category = "Lifestyle",
                    Brand = "Reebok",
                    Size = "40",
                    Color = "White",
                    ImageUrl = "https://images.unsplash.com/photo-1600269452121-4f2416e55c28?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=2035&q=80",
                    CreatedAt = DateTime.UtcNow
                }
            };

            // Add products to the database
            await context.Products.AddRangeAsync(products);
            await context.SaveChangesAsync();

            Console.WriteLine("Sample products seeded successfully!");
        }
    }
} 