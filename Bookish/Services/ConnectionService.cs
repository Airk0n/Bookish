namespace Bookish.Services
{
    public interface IConnectionService
    {
        public string ConnectionString { get; set; }
    }
    public class ConnectionService : IConnectionService
    {
        private string connectionString = "Server=10.50.2.40;Port=5432;Database=bookish;Username=postgres;Password=apprentice";
        public string ConnectionString
        {
            get { return connectionString;}
            set { }
        }

    }
}