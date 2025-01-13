using System.ComponentModel.DataAnnotations;

namespace GerenciadorDeLivros.Models
{
    public class LivroModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo Título é obrigatório")]
        public required string Titulo { get; set; }
        [Required(ErrorMessage = "O campo Autor é obrigatório")]
        public required string Autor { get; set; }
        [Required(ErrorMessage = "O campo Editora é obrigatório")]
        public required string Editora { get; set; }
    }
}
