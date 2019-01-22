using KeyCloakSSODotnetCore.Helpers.KeyCloakDomain;
using KeyCloakSSODotnetCore.Helpers.KeyCloakServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace KeyCloakSSODotnetCore.Helpers.OAuthClients.Filters
{
    public class ValidateTokenStateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var accessToken = context.HttpContext.Request.Headers["Authorization"];

            if (string.IsNullOrEmpty(accessToken))
                context.Result = new UnauthorizedResult();
            else
            {
                accessToken = accessToken.ToString().Substring("Bearer ".Length);
                var keyCloakClientOptions = (KeyCloakOAuthClientConfig)context.HttpContext.RequestServices.GetService(typeof(KeyCloakOAuthClientConfig));

                var introspectTokenResponse = KeyCloakService.IntrospectAccessToken(keyCloakClientOptions, accessToken);

                if (introspectTokenResponse.IsActive == false)
                    context.Result = new UnauthorizedResult();
            }
        }
    }
}
