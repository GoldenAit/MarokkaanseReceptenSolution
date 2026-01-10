using ModelLibrary.Data;
using ModelLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.Data
{
    public static class DbSeeder
    {
        public static void Seed(AppDbContext context)
        {
            // ------------------------
            // 1. Categorieën toevoegen
            // ------------------------
            if (!context.Categorieen.Any())
            {
                context.Categorieen.AddRange(
                    new Categorie { Naam = "Hoofdgerechten" },
                    new Categorie { Naam = "Soepen" },
                    new Categorie { Naam = "Brood" },
                    new Categorie { Naam = "Zoetigheden" }
                );
                context.SaveChanges();
            }

            // ------------------------
            // 2. Recepten toevoegen
            // ------------------------
            if (!context.Recepten.Any())
            {
                var hoofdgerechten = context.Categorieen.First(c => c.Naam == "Hoofdgerechten");
                var soepen = context.Categorieen.First(c => c.Naam == "Soepen");
                var brood = context.Categorieen.First(c => c.Naam == "Brood");
                var zoetigheden = context.Categorieen.First(c => c.Naam == "Zoetigheden");

                context.Recepten.AddRange(
                    new Recept { Naam = "Couscous met groenten", CategorieId = hoofdgerechten.Id },
                    new Recept { Naam = "Tajine kip met olijven", CategorieId = hoofdgerechten.Id },
                    new Recept { Naam = "Harira (soep)", CategorieId = soepen.Id },
                    new Recept { Naam = "Batbout (Marokkaans brood)", CategorieId = brood.Id },
                    new Recept { Naam = "Chebakia (zoetigheid)", CategorieId = zoetigheden.Id }
                );
                context.SaveChanges();
            }

            // ------------------------
            // 3. Ingrediënten toevoegen
            // ------------------------
            if (!context.Ingredienten.Any())
            {
                var couscous = context.Recepten.First(r => r.Naam == "Couscous met groenten");
                var tajine = context.Recepten.First(r => r.Naam == "Tajine kip met olijven");
                var harira = context.Recepten.First(r => r.Naam == "Harira (soep)");
                var batbout = context.Recepten.First(r => r.Naam == "Batbout (Marokkaans brood)");
                var chebakia = context.Recepten.First(r => r.Naam == "Chebakia (zoetigheid)");

                context.Ingredienten.AddRange(
                    // Couscous
                    new Ingredient { Naam = "Couscous", Hoeveelheid = "500g", ReceptId = couscous.Id },
                    new Ingredient { Naam = "Wortels", Hoeveelheid = "200g", ReceptId = couscous.Id },
                    new Ingredient { Naam = "Courgette", Hoeveelheid = "200g", ReceptId = couscous.Id },
                    new Ingredient { Naam = "Kikkererwten", Hoeveelheid = "150g", ReceptId = couscous.Id },

                    // Tajine kip
                    new Ingredient { Naam = "Kip", Hoeveelheid = "1 kg", ReceptId = tajine.Id },
                    new Ingredient { Naam = "Uien", Hoeveelheid = "2 stuks", ReceptId = tajine.Id },
                    new Ingredient { Naam = "Olijven", Hoeveelheid = "100g", ReceptId = tajine.Id },
                    new Ingredient { Naam = "Citroen (geconserveerd)", Hoeveelheid = "1 stuk", ReceptId = tajine.Id },

                    // Harira
                    new Ingredient { Naam = "Tomatenpuree", Hoeveelheid = "200g", ReceptId = harira.Id },
                    new Ingredient { Naam = "Linzen", Hoeveelheid = "100g", ReceptId = harira.Id },
                    new Ingredient { Naam = "Kikkererwten", Hoeveelheid = "100g", ReceptId = harira.Id },
                    new Ingredient { Naam = "Lamsvlees", Hoeveelheid = "150g", ReceptId = harira.Id },

                    // Batbout
                    new Ingredient { Naam = "Bloem", Hoeveelheid = "500g", ReceptId = batbout.Id },
                    new Ingredient { Naam = "Gist", Hoeveelheid = "7g", ReceptId = batbout.Id },
                    new Ingredient { Naam = "Water", Hoeveelheid = "250ml", ReceptId = batbout.Id },

                    // Chebakia
                    new Ingredient { Naam = "Bloem", Hoeveelheid = "500g", ReceptId = chebakia.Id },
                    new Ingredient { Naam = "Sesamzaad", Hoeveelheid = "100g", ReceptId = chebakia.Id },
                    new Ingredient { Naam = "Honing", Hoeveelheid = "200ml", ReceptId = chebakia.Id },
                    new Ingredient { Naam = "Sinaasappelbloesemwater", Hoeveelheid = "2 el", ReceptId = chebakia.Id }
                );
                context.SaveChanges();
            }
        }
    }
}

