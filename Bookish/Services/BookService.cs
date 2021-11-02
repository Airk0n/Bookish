using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Bookish.Models.Database;
using Dapper;
using Npgsql;


namespace Bookish.Services
{
    public interface IBookService
    {
        IEnumerable<Book> GetAllBooks();
    }


    public class BookService : IBookService
    {
        private const string ConnectionString =
            "Server=localhost;Port=5432;Database=bookish;Username=postgres;Password=apprentice";

        public IEnumerable<Book> GetAllBooks()
        {
            using var connection = new NpgsqlConnection(ConnectionString);
            return connection.Query<Book>("SELECT id FROM books");
        }
        
    }
}