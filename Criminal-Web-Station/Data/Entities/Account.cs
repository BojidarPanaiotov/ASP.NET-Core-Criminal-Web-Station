using Microsoft.AspNetCore.Identity;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Criminal_Web_Station.Data.Entities
{
    public class Account:IdentityUser
    {
        public DateTime CreatedOn { get; init; } = DateTime.Now;
        public IEnumerable<Firearm> Firearms { get; init; } = new HashSet<Firearm>();
        public IEnumerable<ColdWeapon> ColdWeapons { get; init; } = new HashSet<ColdWeapon>();
        public IEnumerable<Hitman> Hitmans { get; init; } = new HashSet<Hitman>();
    }
}
