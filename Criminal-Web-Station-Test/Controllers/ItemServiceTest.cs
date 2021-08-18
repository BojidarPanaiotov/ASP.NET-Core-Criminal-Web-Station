using Criminal_Web_Station_Test.Mocks;
using System.Linq;
using Xunit;

namespace Criminal_Web_Station_Test.Controllers
{
    public class ItemServiceTest
    {
        [Fact]
        public void AllCategoriesShouldReturnCorretRessult()
        {
            var itemControllerMock = ItemServiceMock.Instance;
            var res = itemControllerMock.AllCategories().ToList();

            Assert.NotNull(res);
            Assert.Equal("CategoriId1", res[0].Id);
            Assert.Equal("Name1", res[0].Name);
            Assert.Equal("CategoriId2", res[1].Id);
            Assert.Equal("Name2", res[1].Name);
        }
    }
}
