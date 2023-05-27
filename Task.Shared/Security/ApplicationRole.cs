using Microsoft.AspNetCore.Identity;

namespace Task.Shared.Security
{
    public class ApplicationRole : IdentityRole
    {

        public ApplicationRole(string roleName) : base(roleName)
        {
        }
        public ApplicationRole()
        {

        }
    }
}
