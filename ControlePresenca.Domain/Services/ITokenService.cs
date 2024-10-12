using ControlePresenca.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePresenca.Domain.Services
{
    public interface ITokenService
    {
        Token CreateToken(CustomUsuario usuario);
    }
}
