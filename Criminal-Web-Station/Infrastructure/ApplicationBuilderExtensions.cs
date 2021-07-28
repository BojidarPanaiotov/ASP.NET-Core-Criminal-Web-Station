namespace CarRentingSystem.Infrastructure
{
    using Criminal_Web_Station.Data;
    using Criminal_Web_Station.Data.Entities;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(
            this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var services = serviceScope.ServiceProvider;

            MigrateDatabase(services);
            SeedCategories(services);

            return app;
        }

        private static void MigrateDatabase(IServiceProvider services)
        {
            var context = services.GetRequiredService<ApplicationDbContext>();

            context.Database.Migrate();
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
    }
}
