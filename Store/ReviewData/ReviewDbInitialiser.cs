using Store.ReviewData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.ReviewData
{
    public static class ReviewDbInitialiser
    {
        public static async Task Seed(ReviewDbContext context)
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
