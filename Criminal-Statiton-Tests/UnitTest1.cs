using Criminal_Web_Station.Controllers;
using Criminal_Web_Station.Data.Entities;
using Criminal_Web_Station.Services.Models;
using MyTested.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Criminal_Statiton_Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
            => MyController<HomeController>
            .Instance(controller => controller.
            WithData(GetItems()))
            .Calling(c => c.Index())
            .ShouldReturn()
            .View(view => view
            .WithModelOfType<HomeServiceModel>());

        private IEnumerable<Item> GetItems()
            => Enumerable.Range(0, 10).Select(x => new Item());
    }
}
