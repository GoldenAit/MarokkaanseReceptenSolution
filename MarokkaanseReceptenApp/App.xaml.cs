using System;
using System.Windows;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ModelLibrary;
using ModelLibrary.Data;
using ModelLibrary.Identity;

namespace MarokkaanseReceptenApp
{
    public partial class App : Application
    {
        public static IServiceProvider Services { get; private set; } = null!;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var services = new ServiceCollection();

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(AppConfig.ConnectionString));

            services.AddIdentityCore<AppUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>();

            Services = services.BuildServiceProvider();

            using (var scope = Services.CreateScope())
            {
                var ctx = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                ctx.Database.Migrate();

                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                DbRolesSeeder.SeedRoles(roleManager, userManager);
            }

            /// belangrijk: voorkom dat de app meteen sluit
            ShutdownMode = ShutdownMode.OnLastWindowClose;

            var login = new LoginWindow();
            login.Show();

        }
    }
}
