using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Bookish.Models;
using Bookish.Models.Database;
using Dapper;
using Npgsql;

namespace Bookish.Services
{
    public interface IInventoryService
    {
        IEnumerable<Book> GetOwnedBooks();
        IEnumerable<InventoryModel> GetCurrentInventory();
        int GetBookCount(Book bookToCount);

    }
    public class InventoryService : IInventoryService
    {
        private readonly ConnectionService _connectionService = new ConnectionService();
        public IEnumerable<Book> GetOwnedBooks()
        {
            using var connection = new NpgsqlConnection(_connectionService.ConnectionString);

            return connection.Query<Book>("SELECT books.id, title FROM books INNER JOIN inventory on books.id = inventory.books_pkey ORDER BY inventory.books_pkey ASC");
        }

        public IEnumerable<InventoryModel> GetCurrentInventory()
        {
            using var connection = new NpgsqlConnection(_connectionService.ConnectionString);
            List<InventoryModel> result = new List<InventoryModel>();
            Book lastCheckedBook = null;
            IEnumerable<Book> allBooks = GetOwnedBooks();
            foreach (var book in allBooks)
            {
                if (lastCheckedBook == book) continue;
                lastCheckedBook = book;
                int totalCopies = GetBookCount(book);
                int availableCopies = totalCopies - GetAvailableCopies(book);
                result.Add(new InventoryModel(book, GetBookCount(book), availableCopies));
            }
            return result;
        }

        public int GetBookCount(Book bookToCount)
        {
            using var connection = new NpgsqlConnection(_connectionService.ConnectionString);

            return connection.QuerySingle<int>("SELECT COUNT(*) FROM inventory WHERE books_pkey = @bookToCount.id", bookToCount);
        }

        public int GetAvailableCopies(Book bookToCheck)
        {
            using var connection = new NpgsqlConnection(_connectionService.ConnectionString);
            
            return connection.QuerySingle<int>("SELECT COUNT(\"returnDate\" IS NULL) FROM transactions WHERE \"inventoryId\" = @bookToCheck.id", bookToCheck);
        }
        
    }
}