using Microsoft.AspNetCore.Identity;
using ModelLibrary.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.Data
{
    public static class DbRolesSeeder
    {
        public static void SeedRoles(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
        {
            string[] roles = new[] { "Admin", "User" };
            foreach (var role in roles)
            {
                if (!roleManager.RoleExistsAsync(role).Result)
                {
                    roleManager.CreateAsync(new IdentityRole(role)).Wait();
                }
            }

            // Default Admin account
            string adminEmail = "admin@marokkaanserecepten.com";
            var admin = userManager.FindByEmailAsync(adminEmail).Result;
            if (admin == null)
            {
                admin = new AppUser
                {
                    UserName = "admin",
                    Email = adminEmail,
                    VolledigeNaam = "Administrator"
                };
                userManager.CreateAsync(admin, "Admin123!").Wait();
                userManager.AddToRoleAsync(admin, "Admin").Wait();
            }
        }
    }
}
