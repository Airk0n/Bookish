using System.Collections.Generic;
using Bookish.Models.Database;
using Bookish.Models.Request;
using Dapper;
using Npgsql;

namespace Bookish.Services
{
    public interface IMemberService
    {
        IEnumerable<Member> GetAllMembers();
        void CreateMember(CreateMemberEntryModel postModel);
    }
    public class MembersService : IMemberService
    {
        private const string ConnectionString =
            "Server=10.50.2.92;Port=5432;Database=bookish;Username=postgres;Password=apprentice";
        
        public IEnumerable<Member> GetAllMembers()
        {
            using var connection = new NpgsqlConnection(ConnectionString);

            return connection.Query<Member>("SELECT id,name FROM members");
        }

        public void CreateMember(CreateMemberEntryModel postModel)
        {
            using var connection = new NpgsqlConnection(ConnectionString);

            connection.Execute("INSERT INTO members (name) VALUES (@name);", postModel);
        }
    }
}