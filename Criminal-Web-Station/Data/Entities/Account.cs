using Microsoft.AspNetCore.Identity;
using System;

namespace Criminal_Web_Station.Data.Entities
{
    public class Account:IdentityUser
    {
        public DateTime CreatedOn { get; init; }
    }
}
