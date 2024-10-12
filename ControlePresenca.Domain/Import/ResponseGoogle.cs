using Newtonsoft.Json;

namespace ControlePresenca.Domain.Import
{
    public class ResponseGoogle
    {
        [JsonProperty("id_token")]
        public string IdToken { get; set; }
    }
}
