using System.Collections;
using System.Collections.Generic;
using Bookish.Models.Database;
using Dapper;
using Npgsql;

namespace Bookish.Services
{
    public interface ICollectionService
    {
        IEnumerable<Book> GetOwnedBooks();
    }
    public class CollectionService : ICollectionService
    {
        private readonly ConnectionService _connectionService = new ConnectionService();
        public IEnumerable<Book> GetOwnedBooks()
        {
            using var connection = new NpgsqlConnection(_connectionService.ConnectionString);

            return connection.Query<Book>("SELECT id,Title FROM books"); //TODO: Needs to be specific to owned books, not just all the books that exist.
        }
    }
}