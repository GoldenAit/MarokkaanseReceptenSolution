using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ModelLibrary.Identity;
using ModelLibrary.Models;

namespace ModelLibrary
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // DbSets
        public DbSet<Categorie> Categorieen { get; set; } = null!;
        public DbSet<Recept> Recepten { get; set; } = null!;
        public DbSet<Ingredient> Ingredienten { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // -----------------------------
            // SOFT DELETE (global filters)
            // -----------------------------
            modelBuilder.Entity<Categorie>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Recept>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Ingredient>().HasQueryFilter(x => !x.IsDeleted);

            // Optioneel: users verbergen als deleted
            modelBuilder.Entity<AppUser>().HasQueryFilter(u => !u.IsDeleted);

            // -----------------------------
            // SEED DATA (tabellen)
            // -----------------------------
            modelBuilder.Entity<Categorie>().HasData(
                new Categorie { Id = 1, Naam = "Marokkaans", IsDeleted = false },
                new Categorie { Id = 2, Naam = "Vegetarisch", IsDeleted = false },
                new Categorie { Id = 3, Naam = "Bakrecepten", IsDeleted = false }
            );

            modelBuilder.Entity<Recept>().HasData(
                new Recept
                {
                    Id = 1,
                    Naam = "Tajine met Kip",
                    CategorieId = 1,
                    Bereiding = "Stap voor stap...",
                    FotoPad = "",
                    Herkomst = "Marokko",
                    IsDeleted = false
                },
                new Recept
                {
                    Id = 2,
                    Naam = "Vegetarische Stoof",
                    CategorieId = 2,
                    Bereiding = "Stap voor stap...",
                    FotoPad = "",
                    Herkomst = "Marokko",
                    IsDeleted = false
                },
                new Recept
                {
                    Id = 3,
                    Naam = "Brood",
                    CategorieId = 3,
                    Bereiding = "Stap voor stap...",
                    FotoPad = "",
                    Herkomst = "Marokko",
                    IsDeleted = false
                }
            );

            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { Id = 1, Naam = "Kip", Hoeveelheid = "500g", ReceptId = 1, IsDeleted = false },
                new Ingredient { Id = 2, Naam = "Rijst", Hoeveelheid = "200g", ReceptId = 1, IsDeleted = false },
                new Ingredient { Id = 3, Naam = "Amandelen", Hoeveelheid = "100g", ReceptId = 1, IsDeleted = false }
            );

            // -----------------------------
            // BELANGRIJK:
            // GEEN AppUser HasData met dummy PasswordHash!
            // Rollen + admin user worden aangemaakt via DbRolesSeeder bij startup.
            // -----------------------------
        }
    }
}
