namespace MarokkaanseReceptenApp.Models
{
    public class UserRow
    {
        public string Id { get; set; } = "";
        public string Email { get; set; } = "";
        public string VolledigeNaam { get; set; } = "";
        public bool IsBlocked { get; set; }
        public string Role { get; set; } = "User";
    }
}
