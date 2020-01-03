using Microsoft.EntityFrameworkCore;
using Store.ReviewData.Models;

namespace Store.ReviewData
{
    public class ReviewDbContext : DbContext
    {
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Product> Products { get; set; }

        public ReviewDbContext(DbContextOptions<ReviewDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Review>(x =>
            {
                x.Property(r => r.Id).IsRequired();
                x.HasOne(r => r.Product).WithMany()
                .HasForeignKey(r => r.ProductId)
                .IsRequired();
            });

            modelBuilder.Entity<Product>(x =>
            {
                x.Property(p => p.Name).IsRequired();
                x.Property(p => p.Description).IsRequired();
            });
        }
    }
}

