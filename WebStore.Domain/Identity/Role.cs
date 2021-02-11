using Microsoft.AspNetCore.Identity;

namespace WebStore.Domain.Identity
{
    public class Role : IdentityRole
    {
        public const string Administrators = "Administratots";

        public const string Users = "Users";

        public string Description { get; set; }
    }
}
