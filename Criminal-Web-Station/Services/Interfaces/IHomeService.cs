using Criminal_Web_Station.Services.Models;
using System.Collections.Generic;

namespace Criminal_Web_Station.Services.Interfaces
{
    public interface IHomeService
    {
        IEnumerable<T> TopThreeItems<T>();
        HomeServiceModel GetMainContext();
    }
}
