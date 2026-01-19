using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;

using System.Collections.Generic;

namespace ModelLibrary.Models
{
    public class Recept
    {
        public int Id { get; set; }
        public string Naam { get; set; } = string.Empty;
        public int CategorieId { get; set; }
        public string Bereiding { get; set; } = string.Empty;
        public string FotoPad { get; set; } = string.Empty;
        public string Herkomst { get; set; } = string.Empty;
        public bool IsDeleted { get; set; } = false;

        public virtual Categorie Categorie { get; set; } = null!;
        public virtual ICollection<Ingredient> Ingredienten { get; set; } = new List<Ingredient>();
    }
}

