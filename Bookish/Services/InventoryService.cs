using System.Collections;
using System.Collections.Generic;
using Bookish.Models.Database;
using Dapper;
using Npgsql;

namespace Bookish.Services
{
    public interface IInventoryService
    {
        IEnumerable<Book> GetOwnedBooks();
    }
    public class InventoryService : IInventoryService
    {
        private readonly ConnectionService _connectionService = new ConnectionService();
        public IEnumerable<Book> GetOwnedBooks()
        {
            using var connection = new NpgsqlConnection(_connectionService.ConnectionString);

            return connection.Query<Book>("SELECT books.id, title FROM books INNER JOIN inventory on books.id = inventory.books_pkey");
        }
    }
}