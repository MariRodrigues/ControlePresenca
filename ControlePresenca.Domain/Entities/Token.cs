using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePresenca.Domain.Entities
{
    public class Token
    {
        public string Value { get; set; }

        public Token (string value)
        {
            Value = value;
        }
    }
}
