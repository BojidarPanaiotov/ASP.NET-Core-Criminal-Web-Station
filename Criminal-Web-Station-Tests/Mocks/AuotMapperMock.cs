namespace CarRentingSystem.Test.Mocks
{
    using AutoMapper;
    using Criminal_Web_Station.Services.AutoMapper;

    public static class MapperMock
    {
        public static IMapper Instance
        {
            get
            {
                var mapperConfiguration = new MapperConfiguration(config =>
                {
                    config.AddProfile<AutoMapping>();
                });

                return new Mapper(mapperConfiguration);
            }
        }
    }
}