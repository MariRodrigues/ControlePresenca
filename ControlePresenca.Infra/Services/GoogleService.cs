using ControlePresenca.Domain.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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

        public async Task<string> GetToken(string code)
        {
            var tokenEndpoint = "https://oauth2.googleapis.com/token";

            // Dados para enviar no corpo da solicitação POST
            var formData = new Dictionary<string, string>
        {
            { "code", code },
            { "client_id", "686934782381-05r2o0rcdkagb151fq39r7u90a96l5ha.apps.googleusercontent.com" },
            { "client_secret", "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" },
            { "redirect_uri", "https://localhost:5001/signin-google-callback" },
            { "grant_type", "authorization_code" }
        };

            // Criar o conteúdo da solicitação HTTP com os dados do formulário
            var content = new FormUrlEncodedContent(formData);

            // Enviar a solicitação POST para o endpoint do Google
            var response = await _client.PostAsync(tokenEndpoint, content);

            // Ler o conteúdo da resposta como uma string
            var responseContent = await response.Content.ReadAsStringAsync();

            return responseContent;
        }
    }
}
