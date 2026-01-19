using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Naam { get; set; } = string.Empty;
        public string Hoeveelheid { get; set; } = string.Empty;
        public int ReceptId { get; set; }
        public bool IsDeleted { get; set; } = false;

        public virtual Recept Recept { get; set; } = null!;
    }
}



