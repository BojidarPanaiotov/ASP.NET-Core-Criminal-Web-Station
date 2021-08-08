namespace Criminal_Web_Station.Data
{
    using Criminal_Web_Station.Data.Entities;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

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
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Account>()
                .HasOne(a => a.CreditCard)
                .WithOne(b => b.Account)
                .HasForeignKey<CreditCard>(c => c.AccountId);

            base.OnModelCreating(builder);
        }

        public DbSet<Account> Accounts { get; init; }
        public DbSet<Item> Items { get; init; }
        public DbSet<Category> Categories { get; init; }
        public DbSet<CreditCard> CreditCards { get; init; }
        public DbSet<Purchase> Purchases { get; init; }
    }
}
