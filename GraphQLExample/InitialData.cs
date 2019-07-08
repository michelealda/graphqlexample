using System;
using GraphQLExample.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;

namespace GraphQLExample
{
    public static class InitialData
    {
        public static void Seed(this ProductDbContext dbContext)
        {
            dbContext.Database.EnsureCreated();

            if (dbContext.Products.Any()) return;

            dbContext.Products.Add(new Product
            {
                Name = "Mountain Walkers",
                Description = "Use these sturdy shoes to pass any mountain range with ease.",
                Price = 219.5m,
                Rating = 4,
                Type = ProductTypes.Boots,
                Stock = 12,
                PhotoFileName = "shutterstock_66842440.jpg",
                IntroducedAt = DateTimeOffset.Now.AddMonths(-1)
            });

            dbContext.Products.Add(new Product
            {
                Name = "Army Slippers",
                Description = "For your everyday marches in the army.",
                Price = 125.9m,
                Rating = 3,
                Type = ProductTypes.Boots,
                Stock = 56,
                PhotoFileName = "shutterstock_222721876.jpg",
                IntroducedAt = DateTimeOffset.Now.AddMonths(-1)
            });

            dbContext.Products.Add(new Product
            {
                Name = "Backpack Deluxe",
                Description = "This backpack can survive any tornado.",
                Price = 199.99m,
                Rating = 5,
                Type = ProductTypes.ClimbingGear,
                Stock = 66,
                PhotoFileName = "shutterstock_6170527.jpg",
                IntroducedAt = DateTimeOffset.Now.AddMonths(-1)
            });

            dbContext.Products.Add(new Product
            {
                Name = "Climbing Kit",
                Description = "Anything you need to climb the mount Everest.",
                Price = 299.5m,
                Rating = 5,
                Type = ProductTypes.ClimbingGear,
                Stock = 3,
                PhotoFileName = "shutterstock_48040747.jpg",
                IntroducedAt = DateTimeOffset.Now.AddMonths(-1)
            });

            dbContext.Products.Add(new Product
            {
                Name = "Blue Racer",
                Description = "Simply the fastest kayak on earth and beyond for 2 persons.",
                Price = 350m,
                Rating = 5,
                Type = ProductTypes.Kayaks,
                Stock = 8,
                PhotoFileName = "shutterstock_441989509.jpg",
                IntroducedAt = DateTimeOffset.Now.AddMonths(-1)
            });

            dbContext.Products.Add(new Product
            {
                Name = "Orange Demon",
                Description = "One person kayak with hyper boost button.",
                Price = 450m,
                Rating = 2,
                Type = ProductTypes.Kayaks,
                Stock = 1,
                PhotoFileName = "shutterstock_495259978.jpg",
                IntroducedAt = DateTimeOffset.Now.AddMonths(-1)
            });

            dbContext.SaveChanges();
        }
    }
}