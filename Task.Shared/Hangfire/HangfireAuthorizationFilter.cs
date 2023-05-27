using Hangfire.Dashboard;
using Microsoft.AspNetCore.Builder;

namespace Tasel.Shared.Hangfire
{
    public class HangfireAuthorizationFilter : IDashboardAuthorizationFilter
    {
        // private readonly UserManager<IdentityUser> _userManager;

        public HangfireAuthorizationFilter(IApplicationBuilder builder)
        {
            // _userManager = builder.ApplicationServices.GetService<UserManager<IdentityUser>>();
        }

        public bool Authorize(DashboardContext context)
        {
            var httpContext = context.GetHttpContext();
            try
            {
                if (httpContext.User.Identity.IsAuthenticated)
                {
                    return true;
                    // var userEmail = httpContext.User.Identity.Name;
                    // var identityUser = _userManager?.FindByEmailAsync(userEmail).Result;
                    // if (identityUser != null)
                    // {
                    //     if (_userManager.IsInRoleAsync(identityUser, RoleEnum.SuperAdmin.ToString()).Result)
                    //         return true;
                    // }
                }
            }
            catch
            {
                httpContext.Response.Redirect("/Identity/Account/Login");
                return true;
            }

            httpContext.Response.Redirect("/Identity/Account/Login");
            return true;
        }
    }
}