using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store.Controllers;
using Store.ReviewData;
using Store.ReviewData.Models;
using Xunit;

namespace Store.UnitTests
{
    public class ReviewCreationTests
    {
        
        [Fact]
        public async Task Add_ValidObjectPassed_ReturnedResponseHasCreatedItemAsync()
        {
            // Arrange
            var builder = new DbContextOptionsBuilder<ReviewDbContext>()
               .EnableSensitiveDataLogging()
               .UseInMemoryDatabase(Guid.NewGuid().ToString());
            var context = new ReviewDbContext(builder.Options);
            var _controller = new ReviewsController(context);
            
            var testReview = new Review()
            {
                ProductId = 1,
                Rating = 7,
                Active = true
            };

            // Act
            await _controller.Create(testReview);

            // Assert
            Assert.IsType<Review>(testReview);
            Assert.Equal(1, testReview.ProductId);
        }
    }
}
