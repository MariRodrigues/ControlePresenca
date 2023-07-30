using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ControlePresenca.Domain.Import
{
    public class ResponseGoogle
    {
        [JsonProperty("id_token")]
        public string IdToken { get; set; }

    }
}
