using System;
using System.Data;
using System.Data.SqlClient;

using Dapper;

namespace Bookish
{
    public static class DbInteractions
    {
        public static async void test()
        {
            using IDbConnection connection =
                new SqlConnection("Server=localhost, 5432;User=postgres;Password=123bk123;Database=Bookish");

            var data =
                await connection.QueryAsync<string>("SELECT * FROM hello");

            foreach (var x in data)
            {
                Console.WriteLine($"One piece of data {x}");
            }
        }

        // TODO: Hook up to database.
        // I'm ok with sending SQL and dealing with the response.
        // However i'm struggling with Initial set-up.
    }
}