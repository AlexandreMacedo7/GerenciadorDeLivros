namespace GerenciadorDeLivros.Models
{
    public class LivroModel
    {
        public int Id { get; set; }
        public required string Titulo { get; set; }
        public required string Autor { get; set; }
        public required string Editora { get; set; }
    }
}
