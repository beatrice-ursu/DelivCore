using Auth0.ManagementApi;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelivCore.BusinessLayer.UserService
{
    public class UserService: IUserService
    {
        protected string GenerateToken()
        {
            var scopes = new
            {
                users = new
                {
                    actions = new string[] { "read", "create", "update", "delete" }
                },
                connections = new
                {
                    actions = new string[] { "create", "delete" }
                },
                //users_app_metadata = new
                //{
                //    actions = new string[] { "update" }
                //},
                //logs = new
                //{
                //    actions = new string[] { "read" }
                //}
            };

            string jti = Guid.NewGuid().ToString("N");

            return GenerateToken(scopes, jti);
        }

        protected string GenerateToken(object scopes, string jti)
        {
            string apiKey = ConfigurationManager.AppSettings["auth0:ClientId"];
            string apiSecret = ConfigurationManager.AppSettings["auth0:ClientSecret"];

            // Set token payload
            var payload = new Dictionary<string, object>()
            {
                {"aud", apiKey},
                {"jti", jti},
                {"scopes", scopes}
            };

            var keyAsBase64 = apiSecret.Replace('_', '/').Replace('-', '+');
            var secret = Convert.FromBase64String(keyAsBase64);
            return JWT.JsonWebToken.Encode(payload, secret, JWT.JwtHashAlgorithm.HS256);
        }

        protected ManagementApiClient GetApiClient()
        {
            return new ManagementApiClient(GenerateToken(), ConfigurationManager.AppSettings["auth0:Domain"]);
        }

        //pentru emtodele de aici in jos le treci in Interfgata, adapatat ela nevoie

            //metoda asta este asincrona si trebuie apelata asa
            // var usernames = await _userservice.GetUserNames()
            // asta p sa te forteze ca funtia de unde o apelezi sa fie async cum e si asta
        public async Task<List<string>> GetUserNames()
        {
            var client = GetApiClient();
            var users = await client.Users.GetAllAsync();

            return users.Select(x => x.FullName).ToList();
        }
    }
}
