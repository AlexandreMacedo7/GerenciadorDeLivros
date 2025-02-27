﻿using GerenciadorDeLivros.Models;
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

        public List<LivroModel> getAll()
        {
            var livros = new List<LivroModel>();
            using (var connection = new MySqlConnection(_conectionString))
            {
                connection.Open();
                using (var command = new MySqlCommand("SELECT * FROM Livros;", connection))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        livros.Add(new LivroModel
                        {
                            Id = reader.GetInt32("Id"),
                            Titulo = reader.GetString("Titulo"),
                            Autor = reader.GetString("Autor"),
                            Editora = reader.GetString("Editora")
                        });
                    }
                }
            }
            return livros;
        }
        
        public LivroModel GetById(int id)
        {
            using (var connection = new MySqlConnection(_conectionString))
            {
                connection.Open();
                using (var command = new MySqlCommand("SELECT * FROM Livros WHERE Id = @Id;", connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    var reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        return new LivroModel
                        {
                            Id = reader.GetInt32("Id"),
                            Titulo = reader.GetString("Titulo"),
                            Autor = reader.GetString("Autor"),
                            Editora = reader.GetString("Editora")
                        };
                    }
                    else
                    {
                        throw new KeyNotFoundException($"Livro com Id = {id} não encontrado.");
                    }
                }
            }
        }

        public LivroModel UpdateLivro(LivroModel livroAtualizado)
        {
            using (var connection = new MySqlConnection(_conectionString))
            {
                connection.Open();
                using (var command = new MySqlCommand("UPDATE Livros SET Titulo = @Titulo, Autor = @Autor, Editora = @Editora WHERE Id = @Id;", connection))
                {
                    command.Parameters.AddWithValue("@Titulo", livroAtualizado.Titulo);
                    command.Parameters.AddWithValue("@Autor", livroAtualizado.Autor);
                    command.Parameters.AddWithValue("@Editora", livroAtualizado.Editora);
                    command.Parameters.AddWithValue("@Id", livroAtualizado.Id);

                    command.ExecuteNonQuery();
                }
            }
            return livroAtualizado;
        }

        public void DeleteLivro(int id)
        {
            using (var connection = new MySqlConnection(_conectionString))
            {
                connection.Open();

                using (var command = new MySqlCommand("DELETE FROM Livros WHERE Id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", id);


                    command.ExecuteNonQuery();
                }
            }
        }
    }
}

