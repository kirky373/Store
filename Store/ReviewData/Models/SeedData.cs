using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.ReviewData.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ReviewDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ReviewDbContext>>()))
            {
                // Look for any movies.
                if (context.Products.Any())
                {
                    return;   // DB has been seeded
                }

                context.Products.AddRange(
                    new Product
                    {
                        Name = "Iphone",
                        Description = "Bad phone"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
