using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer.Repository
{
    public class BaseRepository
    {
        private readonly string ConnectionString;
        public BaseRepository(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        public IDbConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}
