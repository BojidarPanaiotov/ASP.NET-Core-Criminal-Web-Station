namespace Criminal_Web_Station.Services.Interfaces
{
using Criminal_Web_Station.Services.Models;
using System.Collections.Generic;

    public interface IHomeService
    {
        IEnumerable<T> TopThreeItems<T>();
        HomeServiceModel GetHomePageData();
    }
}
