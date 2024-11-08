using Microsoft.AspNetCore.Identity;

namespace TheWayShop.AppData
{
    public class AppUser : IdentityUser
    {
        public String? FirstName { get; set; }
        public String? LastName { get; set; }

    }
}
