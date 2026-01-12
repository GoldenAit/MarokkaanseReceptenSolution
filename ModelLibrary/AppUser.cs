using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;
namespace ModelLibrary.Identity
{
    public class AppUser : IdentityUser
    {
        public string FavoriteCuisine { get; set; } // extra veld
        public string VolledigeNaam { get; set; }
    }
}

