namespace CarRentingSystem.Test.Mocks
{
    using System;
    using Criminal_Web_Station.Data;
    using Microsoft.EntityFrameworkCore;

    public static class DatabaseMock
    {
        public static ApplicationDbContext Instance
        {
            get
            {
                var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseSqlServer(Guid.NewGuid().ToString())
                    .Options;

                return new ApplicationDbContext(dbContextOptions);
            }
        }
    }
}