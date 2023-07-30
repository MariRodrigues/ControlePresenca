using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePresenca.Domain.Services
{
    public interface IGoogleService
    {
        Task<string> GetToken (string code);
    }
}
