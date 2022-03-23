using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Security.Claims;

namespace LanguageDailyTraining.Service.Extensions
{
    public class CustomAuthorization
    {
        public static bool ValidateUserClaim(HttpContext context, string claimName, string claimValue)
        {
            return context.User.Identity.IsAuthenticated &&
                   context.User.Claims.Any(c => c.Type == claimName && c.Value.Contains(claimValue));
        }
    }

    public class ClaimsAuthorizeAttribute : TypeFilterAttribute // Attribute sufix: identity pattern
    {
        public ClaimsAuthorizeAttribute(string claimName, string claimValue) : base(typeof(CustomAuthorizationClaimFilter))
        {
            Arguments = new object[] { new Claim(claimName, claimValue) };
        }
    }

    public class CustomAuthorizationClaimFilter : IAuthorizationFilter
    {
        private readonly Claim claim;

        public CustomAuthorizationClaimFilter(Claim claim)
        {
            this.claim = claim;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.User.Identity.IsAuthenticated)
            {
                context.Result = new StatusCodeResult(401);
                return;
            }

            if (!CustomAuthorization.ValidateUserClaim(context.HttpContext, claim.Type, claim.Value))
            {
                context.Result = new StatusCodeResult(403);
            }
        }
    }
}
