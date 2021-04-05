using System;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using BookStroe.Models;
using System.Security.Claims;

namespace BookStroe.Claims
{
    public class ApplicationUserClaimsPrincipalFactory: UserClaimsPrincipalFactory<ApplicationUser,IdentityRole>
    {
        public ApplicationUserClaimsPrincipalFactory(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole>roleManager, IOptions<IdentityOptions> options):base(userManager,roleManager,options)
        {
        }

       protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim("FirstName", user.FirstName ?? ""));
            identity.AddClaim(new Claim("LastName", user.LastName ?? ""));
            return identity;
        }
    }
}
