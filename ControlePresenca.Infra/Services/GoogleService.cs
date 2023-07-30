using ControlePresenca.Domain.Entities;
using ControlePresenca.Domain.Import;
using ControlePresenca.Domain.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace ControlePresenca.Infra.Services
{
    public class GoogleService : IGoogleService
    {
        private readonly HttpClient _client;

        public GoogleService(HttpClient client)
        {
            _client = client;
        }

        public async Task<CustomUsuario> GetToken(string code)
        {
            var tokenEndpoint = "https://oauth2.googleapis.com/token";

            var formData = new Dictionary<string, string>
            {
                { "code", code },
                { "client_id", "686934782381-05r2o0rcdkagb151fq39r7u90a96l5ha.apps.googleusercontent.com" },
                { "client_secret", "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" },
                { "redirect_uri", "https://localhost:5001/signin-google-callback" },
                { "grant_type", "authorization_code" }
            };

            var content = new FormUrlEncodedContent(formData);

            var response = await _client.PostAsync(tokenEndpoint, content);

            if (!response.IsSuccessStatusCode)
                return null;

            var responseContent = await response.Content.ReadAsStringAsync();

            var responseGoogle = JsonConvert.DeserializeObject<ResponseGoogle>(responseContent);

            var userAuthenticated = GetInfosTokenGoogle(responseGoogle.IdToken);

            return userAuthenticated;
        }

        private CustomUsuario GetInfosTokenGoogle(string accessToken)
        {
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(accessToken);

            // Agora você pode acessar as informações do usuário no token
            var name = token.Claims.FirstOrDefault(c => c.Type == "name")?.Value;
            var email = token.Claims.FirstOrDefault(c => c.Type == "email")?.Value;
            var first_name = token.Claims.FirstOrDefault(c => c.Type == "given_name")?.Value;

            CustomUsuario usuario = new CustomUsuario()
            {
                Name = name,
                Email = email,
                UserName = first_name
            };

            return usuario;
        }
    }
}
