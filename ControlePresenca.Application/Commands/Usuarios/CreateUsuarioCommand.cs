using ControlePresenca.Application.Response;
using MediatR;
using System.ComponentModel.DataAnnotations;


namespace ControlePresenca.Application.Commands.Usuarios
{
    public class CreateUsuarioCommand : IRequest<ResponseApi>
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail em formato inválido.")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "As senhas não conferem.")]
        public string Repassword { get; set; }
    }
}
