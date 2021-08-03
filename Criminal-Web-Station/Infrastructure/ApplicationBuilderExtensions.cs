namespace CarRentingSystem.Infrastructure
{
    using Criminal_Web_Station.Data;
    using Criminal_Web_Station.Data.Entities;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using static Criminal_Web_Station.Areas.Admin.AdminConstants;
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(
            this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var services = serviceScope.ServiceProvider;

            MigrateDatabase(services);
            //SeedAdministrator(services); BUG FIX IT!
            SeedCategories(services);
            SeedItemForAdmin(services);

            return app;
        }

        private static void MigrateDatabase(IServiceProvider services)
        {
            var context = services.GetRequiredService<ApplicationDbContext>();

            context.Database.Migrate();
        }
        private static void SeedAdministrator(IServiceProvider services)
        {
            var userManager = services.GetRequiredService<UserManager<Account>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            Task
                .Run(async () =>
                {
                    if (await roleManager.RoleExistsAsync(AdministratorRoleName))
                    {
                        return;
                    }

                    var role = new IdentityRole { Name = AdministratorRoleName };

                    await roleManager.CreateAsync(role);

                    const string adminEmail = "admin0@abv.bg";
                    const string adminPassword = "Test123.";

                    var user = new Account
                    {
                        Email = adminEmail,
                        UserName = adminEmail,
                    };

                    await userManager.CreateAsync(user, adminPassword);

                    await userManager.AddToRoleAsync(user, role.Name);
                })
                .GetAwaiter()
                .GetResult();
        }
        private static void SeedCategories(IServiceProvider services)
        {
            var context = services.GetRequiredService<ApplicationDbContext>();

            if (context.Categories.Any())
            {
                return;
            }

            context.Categories.AddRange(new[]
            {
                new Category{Name = "Firearm"},
                new Category{Name = "ColdWeapon"},
                new Category{Name = "Hitman"},
                new Category{Name = "Drug"},
                new Category{Name = "Other "}
            });

            context.SaveChangesAsync();
        }
        //<=== ONLY FOR TESTING PURPOSES ===>
        private static void SeedItemForAdmin(IServiceProvider services)
        {
            var context = services.GetRequiredService<ApplicationDbContext>();

            var item_1 = new Item
            {
                AccountId = "36da6bed-127c-40e6-a917-48729987c679",
                Name = "AK-47",
                Price = 3500.50m,
                Weight = 12.5m,
                MainImgUrl = "https://counterstrikeblog.com/wp-content/uploads/2015/10/download1.jpg",
                Description = "Short description about the russian weapon",
                CategoryId = "fcbb88dc-3629-45ca-b360-2a12ca1c5504",
                CreatedOn = DateTime.Now,
                LastUpdate = DateTime.Now,
            };
            var item_2 = new Item
            {
                AccountId = "36da6bed-127c-40e6-a917-48729987c679",
                Name = "Deagle",
                Price = 1250.50m,
                Weight = 7.5m,
                MainImgUrl = "https://nationalinterest.org/sites/default/files/main_images/Profile-Left-sm-1024x683-1024x683.jpg",
                Description = "Very powerful weapon",
                CategoryId = "14a5f2cf-f6f4-48e2-bb1f-c7affb911167",
                CreatedOn = DateTime.Now,
                LastUpdate = DateTime.Now,
            };
            var item_3 = new Item
            {
                AccountId = "36da6bed-127c-40e6-a917-48729987c679",
                Name = "Special Force Knife Ninja 359",
                Price = 9000.32m,
                Weight = 2.30m,
                MainImgUrl = "https://xn--b1agb1afb.com/image/cache/catalog/2128/2129/viber_%D0%B8%D0%B7%D0%BE%D0%B1%D1%80%D0%B0%D0%B6%D0%B5%D0%BD%D0%B8%D0%B5_2019-12-05_11-15-18-800x800.jpg.webp",
                Description = "One of the sharpest knife in the world",
                CategoryId = "5d8389d0-dcbf-4493-9088-8111e14bffb2",
                CreatedOn = DateTime.Now,
                LastUpdate = DateTime.Now,
            };
            var item_4 = new Item
            {
                AccountId = "36da6bed-127c-40e6-a917-48729987c679",
                Name = "Cocain",
                Price = 15000m,
                Weight = 10m,
                MainImgUrl = "https://t4.ftcdn.net/jpg/02/69/74/77/360_F_269747785_FPKKfQypldwcQxubx8Yvdp92GqeHCsjI.jpg",
                Description = "95% cocain, 10 kg for 15 000 dollars",
                CategoryId = "f5be4ba9-f604-421b-876c-234edc96f9fd",
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
        //<=== DELETE AFTER TESTING THIS ===>
    }
}
