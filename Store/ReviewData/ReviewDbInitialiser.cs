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
                new Product { Active = true, Description = "Its an iPhone", Name = "iPhone"},
                new Product { Active = true, Description = "Its an Android phone", Name = "Android Phone"},
                new Product { Active = true, Description = "Bog standard T-Shirt", Name = "T-Shirt"},
                new Product { Active = true, Description = "Put them on your legs", Name = "Trousers"},
            };

            var reviews = new List<Review>
            {
                new Review {ProductId = 2, Rating=4, Comment="Works", Active=true},
                new Review {ProductId = 4, Rating=5, Comment="Fits well", Active=true},
            };

            var staff = new List<Staff>
            {
                new Staff {Name="Callum"}
            };
            products.ForEach(p => context.Products.Add(p));
            reviews.ForEach(r => context.Reviews.Add(r));
            staff.ForEach(s => context.Staff.Add(s));
            await context.SaveChangesAsync();
        }
    }
}
