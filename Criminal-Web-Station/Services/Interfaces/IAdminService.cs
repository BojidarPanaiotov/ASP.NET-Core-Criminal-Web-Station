namespace Criminal_Web_Station.Services.Interfaces
{
    using Criminal_Web_Station.Areas.Admin.Models;
    using System.Collections.Generic;

    public interface IAdminService
    {
        IEnumerable<UserServiceModel> GetAllUsers();
        string GetUsernameById(string accountId);
    }
}
