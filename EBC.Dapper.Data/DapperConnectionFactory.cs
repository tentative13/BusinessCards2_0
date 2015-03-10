using EBC.Dapper.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBC.Dapper.Data
{
    public class DapperConnectionFactory:IConnectionFactory
    {
        public IDbConnection Create()
        {
            var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Main"].ConnectionString);
            DbConnection dbConnection = (DbConnection)sqlConnection;
            dbConnection.Open();
            return dbConnection;
        }
    }
}
