using System.ComponentModel.DataAnnotations;

namespace PriSistema.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome Obrigatorio!")]
        public string? Nome { get; set; }
        [Required(ErrorMessage = "Email Obrigatorio!")]
        [EmailAddress(ErrorMessage = "Email Inválido!")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Celular Obrigatorio!")]
        [Phone(ErrorMessage = "Celular Inválido!")]
        public string? Celular { get; set; }
    }
}
