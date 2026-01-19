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
        public string FavoriteCuisine { get; set; } = string.Empty;
        public string VolledigeNaam { get; set; } = string.Empty;

        public bool IsBlocked { get; set; } = false;
        public bool IsDeleted { get; set; } = false;
    }
}
