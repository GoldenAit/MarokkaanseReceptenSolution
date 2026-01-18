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
        public string Naam { get; set; }
        public string Hoeveelheid { get; set; }
        public int ReceptId { get; set; } // verwijst naar Recept
        public bool IsDeleted { get; set; }

        
        public virtual Recept Recept { get; set; }
    }
}


