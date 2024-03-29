using System;
using Xunit;
using Store.ReviewData;
using Microsoft.EntityFrameworkCore;
using Store.ReviewData.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;

namespace Store.UnitTests
{
    public class DatabaseTests
    {
        //Test for adding data to a in memory database, Purely to test if the DbContext is correct and works
        [Fact]
        public void ShouldBeAbleToAddToInMemoryDb()
        {
            // Arrange
            var builder = new DbContextOptionsBuilder<ReviewDbContext>()
                .EnableSensitiveDataLogging()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());

            using (var context = new ReviewDbContext(builder.Options))
            {
                // Act
                var product = new Product{Active = true, Description = "Poor quality fake faux leather cover loose enough to fit any mobile device.", Name = "Wrap It and Hope Cover"};


                var review = new Review { ProductId = 1, Rating = 3, Comment = "Test comment", Active = true };
                    
                context.Products.Add(product);
                context.Reviews.Add(review);
                context.SaveChanges();

                // Asser
                Assert.Equal(1, context.Reviews.Count(r => r.Comment == "Test comment"));
            };
        }

        //Test for adding data to LocalDb, will try to connect to the database, remove any existing test comments and then try to add a new one.
        [Fact]
        public void ShouldBeAbleToAddToLocalDb()
        {
            // Arrange
            const string ConnectionString = "Data Source = (localdb)\\mssqllocaldb;Database=ReviewsDB;Trusted_Connection=True;MultipleActiveResultSets=true";
            var builder = new DbContextOptionsBuilder<ReviewDbContext>()
                .EnableSensitiveDataLogging()
                .UseSqlServer(connectionString: ConnectionString);

            using (var context = new ReviewDbContext(builder.Options))
            {
                // Act
                context.Reviews.RemoveRange(context.Reviews.Where(r => r.Comment == "Test comment"));

                var review = new Review { ProductId = 1, Rating = 3, Comment = "Test comment", Active = true };

                context.Reviews.Add(review);
                context.SaveChanges();

                // Assert
                Assert.Equal(1, context.Reviews.Count(r => r.Comment == "Test comment"));
            };
        }
        //Test for adding to Azure SQL database, Same as localDB test in that it removes any existing test comments and tries to add a new one.
        [Fact]
        public void ShouldBeAbleToAddDataToAzureDatabase()
        {
            // Arrange
            const string ConnectionString = "Server=tcp:ckreviewsdb.database.windows.net,1433;Initial Catalog=ReviewsDB;Persist Security Info=False;User ID=CKirkwood;Password=UniPass2020;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            var builder = new DbContextOptionsBuilder<ReviewDbContext>()
                .EnableSensitiveDataLogging()
                .UseSqlServer(connectionString: ConnectionString);
            using (var context = new ReviewDbContext(builder.Options))
            {
                // Act
                context.Reviews.RemoveRange(context.Reviews.Where(r => r.Comment == "Test comment"));

                var review = new Review { ProductId = 1, Rating = 3, Comment = "Test comment", Active = true };

                context.Reviews.Add(review);
                context.SaveChanges();

                // Assert
                Assert.Equal(1, context.Reviews.Count(r => r.Comment == "Test comment"));
            };
        }
    }
}
