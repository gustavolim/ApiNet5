using System.ComponentModel.DataAnnotations;

namespace Gerente.Api.ViewModels
{
    public class CriarUsuarioViewModel
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        [MinLength(3, ErrorMessage = "O nome tem que ter no mínimo 3 ctrs.")]
        [MaxLength(30,ErrorMessage = "O nome tem que ter no máximo 30 ctrs.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O Email é obrigatório")]
        [MinLength(10, ErrorMessage = "O Email tem que ter no mínimo 10 ctrs.")]
        [MaxLength(180,ErrorMessage = "O Email tem que ter no máximo 180 ctrs.")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A Senha é obrigatório")]
        [DataType(DataType.Password, ErrorMessage = "Formato inválido de senha")]
        public string Senha { get; set; }
    }
}