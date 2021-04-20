using Microsoft.AspNetCore.Identity;

namespace WebStore.Domain.Identity
{
    public class User : IdentityUser
    {
        public const string Administrator = "Admin";

        public const string DefaultAdminPassword = "admin";

        public string Description { get; set; }
    }
}
