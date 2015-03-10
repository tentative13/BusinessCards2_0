using EBC.Dapper.Data;
using System.Data;
using System.Data.SqlClient;

namespace EBC.Data.Tets
{
    public class TestConnectionFactory : IConnectionFactory
    {
        public IDbConnection Create()
        {
            var cs = @"Data Source=KILOVATIYM\SQLEXPRESS;Initial Catalog=C:\_SOURCESC#\BUSINESSCARDS\MVC\WEBEBC\APP_DATA\EBC.MDF;Integrated Security=true;";
            IDbConnection dbConnection = new SqlConnection(cs);
            dbConnection.Open();
            return dbConnection;
        }
                
    }
}
