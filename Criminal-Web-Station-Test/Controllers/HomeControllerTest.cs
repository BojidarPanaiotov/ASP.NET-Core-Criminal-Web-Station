using Criminal_Web_Station.Controllers;
using Criminal_Web_Station.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Criminal_Web_Station_Test.Controllers
{
    public class HomeControllerTest
    {
        [Fact]
        public void IndexShouldReturnView()
        {
            // Arrange
            var homeController = new HomeController(Mock.Of<IHomeService>());

            // Act
            var result = homeController.Index();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
        }
    }
}
