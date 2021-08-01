namespace Criminal_Web_Station.Services.Models
{
    using Criminal_Web_Station.Models.Item;
    using System.Collections.Generic;
    public class HomeServiceModel
    {
        public int TotalUsers { get; init; }
        public int TotalAdds { get; init; }
        public List<HomeItemModel> TopThreeItems { get; set; }
    }
}
