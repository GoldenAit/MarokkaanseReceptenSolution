using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings =>
                warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // -----------------------------
            // ROLLEN SEEDEN
            // -----------------------------
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = "2", Name = "User", NormalizedName = "USER" }
            );

            // -----------------------------
            // ADMIN USER SEEDEN
            // -----------------------------
            builder.Entity<AppUser>().HasData(
                new AppUser
                {
                    Id = "100",
                    UserName = "admin@marokkaans.be",
                    NormalizedUserName = "ADMIN@MAROKKAANS.BE",
                    Email = "admin@marokkaans.be",
                    NormalizedEmail = "ADMIN@MAROKKAANS.BE",
                    EmailConfirmed = true,
                    FavoriteCuisine = "Marokkaans",
                    VolledigeNaam = "Admin Marokkaans",
                    PasswordHash = "AQAAAAIAAYagAAAAEK8D3dMZx+7cOeFhvI0/b4mcyQmRleN8zB1WJZTfT4xPj7u3YtJ+EztqMIAlMCsNw=="
                }
            );

            // -----------------------------
            // ADMIN AAN ADMIN-ROL KOPPELEN
            // -----------------------------
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { UserId = "100", RoleId = "1" }
            );

            // -----------------------------
            // CATEGORIEËN SEEDEN
            // -----------------------------
            builder.Entity<Categorie>().HasData(
                new Categorie { Id = 1, Naam = "Hoofdgerechten" },
                new Categorie { Id = 2, Naam = "Soepen" },
                new Categorie { Id = 3, Naam = "Brood" },
                new Categorie { Id = 4, Naam = "Zoetigheden" }
            );

            // -----------------------------
            // RECEPTEN SEEDEN
            // -----------------------------
            builder.Entity<Recept>().HasData(
                new Recept
                {
                    Id = 1,
                    Naam = "Tajine met kip",
                    CategorieId = 1,
                    Bereiding = "Traditionele Marokkaanse kip-tajine met groenten en kruiden.",
                    FotoPad = "",
                    Herkomst = "Marokko",
                    IsDeleted = false
                },
                new Recept
                {
                    Id = 2,
                    Naam = "Harira",
                    CategorieId = 2,
                    Bereiding = "Heerlijke Marokkaanse soep, vaak gegeten tijdens Ramadan.",
                    FotoPad = "",
                    Herkomst = "Marokko",
                    IsDeleted = false
                },
                new Recept
                {
                    Id = 3,
                    Naam = "Khobz",
                    CategorieId = 3,
                    Bereiding = "Traditioneel Marokkaans brood.",
                    FotoPad = "",
                    Herkomst = "Marokko",
                    IsDeleted = false
                },
                new Recept
                {
                    Id = 4,
                    Naam = "Chebakia",
                    CategorieId = 4,
                    Bereiding = "Marokkaanse zoetigheid met honing en sesam.",
                    FotoPad = "",
                    Herkomst = "Marokko",
                    IsDeleted = false
                }
            );

            // -----------------------------
            // INGREDIËNTEN SEEDEN (ReceptId aangepast naar bestaande ReceptId's)
            // -----------------------------
            builder.Entity<Ingredient>().HasData(
     new Ingredient { Id = -1, Naam = "Kip", Hoeveelheid = "500g", ReceptId = 1 },
     new Ingredient { Id = -2, Naam = "Lamsvlees", Hoeveelheid = "500g", ReceptId = 1 },
     new Ingredient { Id = -3, Naam = "Rijst", Hoeveelheid = "200g", ReceptId = 1 },
     new Ingredient { Id = -4, Naam = "Amandelen", Hoeveelheid = "100g", ReceptId = 1 },
     new Ingredient { Id = -5, Naam = "Olijfolie", Hoeveelheid = "50ml", ReceptId = 1 },
     new Ingredient { Id = -6, Naam = "Ui", Hoeveelheid = "2 stuks", ReceptId = 1 },
     new Ingredient { Id = -7, Naam = "Knoflook", Hoeveelheid = "3 teentjes", ReceptId = 1 },
     new Ingredient { Id = -8, Naam = "Komijn", Hoeveelheid = "1 tl", ReceptId = 1 },
     new Ingredient { Id = -9, Naam = "Kaneel", Hoeveelheid = "1 tl", ReceptId = 1 },
     new Ingredient { Id = -10, Naam = "Sinaasappel", Hoeveelheid = "1 stuk", ReceptId = 1 }
 );

        }
    }
}
