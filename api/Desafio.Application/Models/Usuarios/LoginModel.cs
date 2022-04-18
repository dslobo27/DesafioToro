using System.ComponentModel.DataAnnotations;

namespace Desafio.Application.Models.Usuarios
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Informe o cpf.")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Informe a senha.")]
        public string Senha { get; set; }
    }
}