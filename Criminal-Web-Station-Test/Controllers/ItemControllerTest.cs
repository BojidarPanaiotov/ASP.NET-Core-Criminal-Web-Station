namespace Criminal_Web_Station_Test.Controllers
{
    using Criminal_Web_Station.Controllers;
    using Criminal_Web_Station.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using Xunit;

    public class ItemControllerTest
    {
        [Fact]
        public void GetCreateShouldReturnViewResultWithModel()
        {
            var itemControllerMock = new ItemController(null, Mock.Of<IItemService>(), Mock.Of<IMarketService>());
            var res = itemControllerMock.Create();

            Assert.NotNull(res);
            Assert.IsType<ViewResult>(res);
        }
    }
}
