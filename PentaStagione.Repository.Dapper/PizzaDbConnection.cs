using System.Configuration;
using System.Data.SqlClient;

namespace PentaStagione.Repository.Dapper
{
    public class DbConnection
    {
        private readonly string _connectionName;

        public SqlConnection Connection => new SqlConnection(ConfigurationManager.ConnectionStrings[_connectionName].ConnectionString);

        public DbConnection(string connectionName)
        {
            _connectionName=connectionName;
        }
    }
}
