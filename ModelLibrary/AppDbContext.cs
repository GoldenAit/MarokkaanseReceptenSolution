using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ModelLibrary.Identity;
using ModelLibrary.Models;

namespace ModelLibrary.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public DbSet<Recept> Recepten { get; set; }
        public DbSet<Categorie> Categorieen { get; set; }
        public DbSet<Ingredient> Ingredienten { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // -----------------------------
            // ROLLEN SEEDEN
            // -----------------------------
            var adminRole = new IdentityRole
            {
                Id = "1",
                Name = "Admin",
                NormalizedName = "ADMIN"
            };

            var userRole = new IdentityRole
            {
                Id = "2",
                Name = "User",
                NormalizedName = "USER"
            };

            builder.Entity<IdentityRole>().HasData(adminRole, userRole);

            // -----------------------------
            // ADMIN USER SEEDEN
            // -----------------------------
            var hasher = new PasswordHasher<AppUser>();

            var adminUser = new AppUser
            {
                Id = "100",
                UserName = "admin@marokkaans.be",
                NormalizedUserName = "ADMIN@MAROKKAANS.BE",
                Email = "admin@marokkaans.be",
                NormalizedEmail = "ADMIN@MAROKKAANS.BE",
                EmailConfirmed = true,
                FavoriteCuisine = "Marokkaans"
            };

            adminUser.PasswordHash = hasher.HashPassword(adminUser, "Admin123!");

            builder.Entity<AppUser>().HasData(adminUser);

            // -----------------------------
            // ADMIN AAN ADMIN-ROL KOPPELEN
            // -----------------------------
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    UserId = "100",
                    RoleId = "1"
                }
            );
        }
    }
}
