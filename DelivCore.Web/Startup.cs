using System.Configuration;
using System.Security.Claims;
using System.Threading.Tasks;
using Auth0.Owin;
using DelivCore.Web;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Newtonsoft.Json.Linq;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace DelivCore.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });

            // Use a cookie to temporarily store information about a user logging in with a third party login provider
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Configure Auth0 authentication
            var options = new Auth0AuthenticationOptions
            {
                ClientId = ConfigurationManager.AppSettings["auth0:ClientId"],
                ClientSecret = ConfigurationManager.AppSettings["auth0:ClientSecret"],
                Domain = ConfigurationManager.AppSettings["auth0:Domain"],
                RedirectPath = new PathString("/Auth0Account/ExternalLoginCallback"),
                Provider = new Auth0AuthenticationProvider
                {
                    OnAuthenticated = context =>
                    {
                        // Get the user's country
                        //JToken countryObject = context.User["country"];
                        //if (countryObject != null)
                        //{
                        //    string country = countryObject.ToObject<string>();

                        //    context.Identity.AddClaim(new Claim("country", country, ClaimValueTypes.String, context.Connection));
                        //}

                        // Get the user's roles
                        var userMetadata = context.User["app_metadata"];
                        var rolesObject = userMetadata?["roles"];
                        if (rolesObject == null) return Task.FromResult(0);

                        var roles = rolesObject.ToObject<string[]>();
                        foreach (var role in roles)
                        {
                            context.Identity.AddClaim(new Claim(ClaimTypes.Role, role, ClaimValueTypes.String, context.Connection));
                        }

                        return Task.FromResult(0);
                    }
                }
            };
            app.UseAuth0Authentication(options);
        }
    }
}