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
        void EditMember(UpdateMemberModel editModel);
        Member GetMember(SelectMemberModel selectModel);
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

        public Member GetMember(SelectMemberModel selectModel)
        {
            using var connection = new NpgsqlConnection(_connectionService.ConnectionString);

            return connection.QuerySingle<Member>("SELECT * FROM members WHERE id = (@id)", selectModel);

        }

        public void EditMember(UpdateMemberModel editModel)
        {
            using var connection = new NpgsqlConnection(_connectionService.ConnectionString);

            connection.Execute("UPDATE members set name = (@name) WHERE id = (@id);", editModel);
        }
    }
}