using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreData.Models;

namespace StoreData
{
    public static class ReviewDbInitialiser
    {
        public static async Task SeedTestData(ReviewDbContext context,
                                              IServiceProvider services)
        {
            if (context.Products.Any())
            {
                return;
            }

            var products = new List<Product>
            {
                new Product { Active = true, Description = "Poor quality fake faux leather cover loose enough to fit any mobile device.", Name = "Wrap It and Hope Cover"},
            };
            products.ForEach(p => context.Products.Add(p));

            await context.SaveChangesAsync();
        }
    }
}
