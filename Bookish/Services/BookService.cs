using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Bookish.Models.Database;
using Bookish.Models.Request;
using Dapper;
using Npgsql;


namespace Bookish.Services
{
    public interface IBookService
    {
        IEnumerable<Book> GetAllBooks();
        void CreateBook(CreateBookEntryModel postModel);
    }


    public class BookService : IBookService
    {
        private readonly ConnectionService _connectionService = new ConnectionService();

        public IEnumerable<Book> GetAllBooks()
        {
            using var connection = new NpgsqlConnection(_connectionService.ConnectionString);
            
            return connection.Query<Book>("SELECT id,Title FROM books");
        }

        public void CreateBook(CreateBookEntryModel postModel)
        {
            using var connection = new NpgsqlConnection(_connectionService.ConnectionString);

            connection.Execute("INSERT INTO books (title) VALUES (@Title);", postModel);
            
        }
    }
}