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
        void RemoveMember(RemoveMemberEntryModel removeModel);
    }
    public class MembersService : IMemberService
    {
        private readonly ConnectionService _connectionService = new ConnectionService();
        
        public IEnumerable<Member> GetAllMembers()
        {
            using var connection = new NpgsqlConnection(_connectionService.ConnectionString);

            return connection.Query<Member>("SELECT id,name FROM members");
        }

        public void CreateMember(CreateMemberEntryModel postModel)
        {
            using var connection = new NpgsqlConnection(_connectionService.ConnectionString);

            connection.Execute("INSERT INTO members (name) VALUES (@name);", postModel);
        }

        public void RemoveMember(RemoveMemberEntryModel removeModel)
        {
            using var connection = new NpgsqlConnection(_connectionService.ConnectionString);

            connection.Execute("DELETE FROM members id WHERE id = (@id);", removeModel);
        }
    }
}