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
        }
    }
}
