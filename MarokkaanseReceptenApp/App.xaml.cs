using System;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ModelLibrary.Data;

namespace MarokkaanseReceptenApp
{
    public partial class App : Application
    {
        public static IServiceProvider Services { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            var services = new ServiceCollection();

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(
                    "Server=(localdb)\\MSSQLLocalDB;Database=MarokkaanseReceptenDb;Trusted_Connection=True;"
                ));

            Services = services.BuildServiceProvider();

            base.OnStartup(e);
        }
    }
}



