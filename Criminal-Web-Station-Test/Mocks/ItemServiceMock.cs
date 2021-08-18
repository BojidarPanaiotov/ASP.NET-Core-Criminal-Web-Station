namespace Criminal_Web_Station_Test.Mocks
{
    using Criminal_Web_Station.Models.Item;
    using Criminal_Web_Station.Services.Interfaces;
    using Criminal_Web_Station.Services.Models;
    using Moq;
    using System.Collections.Generic;

    public static class ItemServiceMock
    {
        public static IItemService Instance
        {
            get
            {
                var itemServiceMock = new Mock<IItemService>();

                itemServiceMock
                    .Setup(s => s.AllCategories())
                    .Returns(new List<CategoryServiceModel>()
                    {
                            new CategoryServiceModel
                            {
                                Id ="CategoriId1",
                                Name = "Name1"
                            },
                            new CategoryServiceModel
                            {
                                Id ="CategoriId2",
                                Name = "Name2"
                            },
                    });

                return itemServiceMock.Object;
            }
        }
    }
}
