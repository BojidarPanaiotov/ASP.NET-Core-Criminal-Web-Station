using System.Collections.Generic;

namespace Criminal_Web_Station.Areas.Admin.Models
{
    public class UsersAdminModel
    {
        public IEnumerable<UserServiceModel> Users { get; set; }
    }
}
