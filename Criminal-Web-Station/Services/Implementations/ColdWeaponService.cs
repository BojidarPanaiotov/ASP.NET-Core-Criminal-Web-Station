using Criminal_Web_Station.Data;
using Criminal_Web_Station.Data.Entities;
using Criminal_Web_Station.Models.Firearm;
using Criminal_Web_Station.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace Criminal_Web_Station.Services.Implementations
{
    public class ColdWeaponService : IColdWeapon
    {
        private readonly ApplicationDbContext context;

        public ColdWeaponService(
            ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task CreateAsync(ColdWeaponInputFormModel coldWeaponInput,string accountId)
        {
            var coldWeaponEntity = new ColdWeapon
            {
                AccountId = accountId,
                Name = coldWeaponInput.Name,
                Price = coldWeaponInput.Price,
                Weight = coldWeaponInput.Weight,
                MainImgUrl = coldWeaponInput.MainImgUrl,
                Description = coldWeaponInput.Description
            };

            await this.context.ColdWeapons.AddAsync(coldWeaponEntity);
            await this.context.SaveChangesAsync();
        }
    }
}
