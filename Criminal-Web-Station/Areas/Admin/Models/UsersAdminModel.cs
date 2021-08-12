
namespace Criminal_Web_Station.Areas.Admin.Models
{
    using System.Collections.Generic;

    public class UsersAdminModel
    {
        public AdminBanInfoFormModel Ban { get; set; }
        public IEnumerable<UserServiceModel> Users { get; set; }
    }
}
