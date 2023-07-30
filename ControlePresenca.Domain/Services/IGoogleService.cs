using ControlePresenca.Domain.Entities;
using ControlePresenca.Domain.Import;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePresenca.Domain.Services
{
    public interface IGoogleService
    {
        Task<CustomUsuario> GetToken(string code);
    }
}
