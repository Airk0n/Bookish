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
        IEnumerable<Book> SearchBook(string searchCriteria);
        Book GetBook(SelectBookModel selectModel);
        void EditBook(UpdateBookModel editModel);
        void DeleteBook(DeleteBookEntryModel removeModel);
    }


    public class BookService : IBookService
    {
        private readonly ConnectionService _connectionService = new ConnectionService();

        public IEnumerable<Book> GetAllBooks()
        {
            using var connection = new NpgsqlConnection(_connectionService.ConnectionString);
            
            return connection.Query<Book>("SELECT * FROM books");
        }

        public void CreateBook(CreateBookEntryModel postModel)
        {
            using var connection = new NpgsqlConnection(_connectionService.ConnectionString);

            connection.Execute("INSERT INTO books (title, year, author, genre) VALUES (@Title, @Year, @Author, @Genre);", postModel);
            
        }

        public IEnumerable<Book> SearchBook(string searchCriteria)
        {
            using var connection = new NpgsqlConnection(_connectionService.ConnectionString);
            
            var parameters = new { Title = searchCriteria};
            
            return connection.Query<Book>("SELECT * FROM books WHERE title = @Title;", parameters);
        }
        
        public void DeleteBook(DeleteBookEntryModel removeModel)
        {
            using var connection = new NpgsqlConnection(_connectionService.ConnectionString);

            connection.Execute("DELETE FROM books id WHERE id = (@id);", removeModel);
        }
        

        public Book GetBook(SelectBookModel selectModel)
        {
            using var connection = new NpgsqlConnection(_connectionService.ConnectionString);
            
            return connection.QuerySingle<Book>("SELECT * FROM books WHERE id = (@id)", selectModel);
        }
        
        public void EditBook(UpdateBookModel editModel)
        {
            using var connection = new NpgsqlConnection(_connectionService.ConnectionString);

            connection.Execute("UPDATE books set title = (@Title), year = (@Year), author = (@Author), genre = (@Genre)  WHERE id = (@id);", editModel);
            
        }
    }
}