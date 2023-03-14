using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePresenca.Application.Response
{
    public class ResponseApi
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }

        public ResponseApi(bool success, string message)
        {
            Success = success;
            Message = message;
        }
    }
}
