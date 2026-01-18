using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ModelLibrary.Models
{
    public class Categorie
    {
        public int Id { get; set; }
        public string Naam { get; set; }

        public virtual ICollection<Recept> Recepten { get; set; } = new List<Recept>();
    }
}


