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
        public bool IsDeleted { get; set; } // soft-delete
        public virtual List<Recept> Recepten { get; set; }
    }
}

