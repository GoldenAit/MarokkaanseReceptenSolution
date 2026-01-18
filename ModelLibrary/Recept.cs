using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;

namespace ModelLibrary.Models
{
    public class Recept
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public int CategorieId { get; set; }
        public string Bereiding { get; set; }
        public string FotoPad { get; set; }
        public string Herkomst { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Categorie Categorie { get; set; }
        public virtual ICollection<Ingredient> Ingredienten { get; set; } = new List<Ingredient>();
    }
}

