using GerenciadorDeLivros.Models;
using MySql.Data.MySqlClient;

namespace GerenciadorDeLivros.Daos
{

    public class LivroDao
    {
        private readonly string _conectionString;

        public LivroDao(string conectionString)
        {
            _conectionString = conectionString;
        }

        public void Create(LivroModel livro)
        {
            using (var connection = new MySqlConnection(_conectionString))
            {
                connection.Open();

                using (var command = new MySqlCommand("INSERT INTO Livros (Titulo, Autor, Editora)" +
                    "VALUES (@Titulo, @Autor, @Editora);", connection))
                {
                    command.Parameters.AddWithValue("@Titulo", livro.Titulo);
                    command.Parameters.AddWithValue("@Autor", livro.Autor);
                    command.Parameters.AddWithValue("@Editora", livro.Editora);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
