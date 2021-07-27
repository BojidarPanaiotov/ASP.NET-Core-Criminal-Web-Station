using Criminal_Web_Station.Controllers;
using Criminal_Web_Station.Models.Firearm;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Criminal_Web_Station.Services.Interfaces
{
    public interface IColdWeapon
    {
        Task CreateAsync(ColdWeaponInputFormModel coldWeaponInput, string accountId);
    }
}
