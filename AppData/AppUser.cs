using Microsoft.AspNetCore.Identity;

namespace TheWayShop.AppData
{
    public class AppUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

    }
}
