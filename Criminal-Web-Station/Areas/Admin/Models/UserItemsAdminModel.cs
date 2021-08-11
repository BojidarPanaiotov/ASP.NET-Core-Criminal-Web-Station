namespace Criminal_Web_Station.Areas.Admin.Models
{
    using System.Collections.Generic;

    public class UserItemsAdminModel
    {
        public string Username { get; init; }
        public List<ItemAdminModel> Items { get; init; }
    }
}
