namespace CarRentingSystem.Infrastructure
{
    using Criminal_Web_Station.Areas.Admin;
    using Criminal_Web_Station.Data;
    using Criminal_Web_Station.Data.Entities;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using static Criminal_Web_Station.WebConstats;
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(
            this IApplicationBuilder app)
        {
            using var copedServices = app.ApplicationServices.CreateScope();
            var serviceProvider = copedServices.ServiceProvider;

            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();

            MigrateDatabase(context);
            SeedCategories(context, serviceProvider);
            SeedItemForAdmin(context, serviceProvider);
            SeedAdministrator(serviceProvider);
            return app;
        }

        private static void MigrateDatabase(ApplicationDbContext context)
        {
            context.Database.Migrate();
        }
        private static void SeedAdministrator(IServiceProvider services)
        {
            var userManager = services.GetRequiredService<UserManager<Account>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            Task.Run(async () =>
            {
                if (await roleManager.RoleExistsAsync(AdminConstants.AdministratorRoleName))
                {
                    return;
                }

                await roleManager.CreateAsync(new IdentityRole { Name = AdminConstants.AdministratorRoleName });

                const string adminEmail = "admin@test.com"; 
                const string adminPassword = "Admin123.";

                var userAdmin = new Account
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true,
                    CreatedOn = DateTime.Now,
                };

                await userManager.CreateAsync(userAdmin, adminPassword);

                await userManager.AddToRoleAsync(userAdmin, AdminConstants.AdministratorRoleName);
            })
                .GetAwaiter()
                .GetResult();
        }
        private static void SeedCategories(ApplicationDbContext context, IServiceProvider services)
        {

            if (context.Categories.Any())
            {
                return;
            }

            context.Categories.AddRange(new[]
            {
                new Category{Name = "Firearm"},
                new Category{Name = "ColdWeapon"},
                new Category{Name = "Drug"},
                new Category{Name = "Other "}
            });

            context.SaveChangesAsync();
        }

        private static void SeedItemForAdmin(ApplicationDbContext context, IServiceProvider services)
        {
            var accountId = context
                .Accounts
                .FirstOrDefault(a => a.UserName == "admin@test.com")
                .Id;

            var item_1 = new Item
            {
                AccountId = accountId,
                Name = "AK-47",
                Price = 3500.50m,
                Weight = 12.5m,
                MainImgUrl = "https://counterstrikeblog.com/wp-content/uploads/2015/10/download1.jpg",
                Description = "Short description about the russian weapon",
                CategoryId = "7e7a2dd9-7a1c-4a31-ad43-396ef6dfd823",
                CreatedOn = DateTime.Now,
                LastUpdate = DateTime.Now,
            };
            var item_2 = new Item
            {
                AccountId = accountId,
                Name = "Deagle",
                Price = 1250.50m,
                Weight = 7.5m,
                MainImgUrl = "https://nationalinterest.org/sites/default/files/main_images/Profile-Left-sm-1024x683-1024x683.jpg",
                Description = "Very powerful weapon",
                CategoryId = "7e7a2dd9-7a1c-4a31-ad43-396ef6dfd823",
                CreatedOn = DateTime.Now,
                LastUpdate = DateTime.Now,
            };
            var item_3 = new Item
            {
                AccountId = accountId,
                Name = "Special Force Knife Ninja 359",
                Price = 9000.32m,
                Weight = 2.30m,
                MainImgUrl = "https://xn--b1agb1afb.com/image/cache/catalog/2128/2129/viber_%D0%B8%D0%B7%D0%BE%D0%B1%D1%80%D0%B0%D0%B6%D0%B5%D0%BD%D0%B8%D0%B5_2019-12-05_11-15-18-800x800.jpg.webp",
                Description = "One of the sharpest knife in the world",
                CategoryId = "fea55501-43fb-4770-96d1-6893669590bf",
                CreatedOn = DateTime.Now,
                LastUpdate = DateTime.Now,
            };
            var item_4 = new Item
            {
                AccountId = accountId,
                Name = "Sniper T95-OS",
                Price = 95459m,
                Weight = 10m,
                MainImgUrl = "https://www.machinegun-figures.com/products_img/21091/C_6.jpg",
                Description = "5500 miles area of vision. One of the deadliest snippers on the planet.",
                CategoryId = "945bccbb-6244-4dd3-8353-822b6035b6f1",
                CreatedOn = DateTime.Now,
                LastUpdate = DateTime.Now,
            };

            context.AddRange(new[]
            {
                item_1,
                item_2,
                item_3,
                item_4,
            });

            context.SaveChanges();
        }
    }
}
