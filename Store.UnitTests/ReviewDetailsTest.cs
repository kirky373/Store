using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Controllers;
using Store.ReviewData;
using Xunit;

namespace Store.UnitTests
{
    public class ReviewDetailsTest
    {
        [Fact]
        public void Index_WhenCalled_ReturnsOkResult()
        {
            //Arrange
            var builder = new DbContextOptionsBuilder<ReviewDbContext>()
                .EnableSensitiveDataLogging()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());
            var context = new ReviewDbContext(builder.Options);
            var _controller = new ReviewsController(context);
            // Act
            var okResult = _controller.Index();

            // Assert
            ViewResult okObjectResult = Assert.IsType<ViewResult>(okResult.Result);
        }
    }
}
