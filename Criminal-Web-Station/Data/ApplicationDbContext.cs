using Criminal_Web_Station.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Criminal_Web_Station.Data
{
    public class ApplicationDbContext : IdentityDbContext<Account>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Account> Accounts { get; init; }
        public DbSet<Firearm> Firearms { get; init; }
        public DbSet<ColdWeapon> ColdWeapons { get; init; }
        public DbSet<Hitman> Hitmans { get; init; }
        public DbSet<Drug> Drugs { get; init; }
    }
}
