using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using global::Dapper;

namespace EBC.DapperData
{
    public static class DapperObjectQueryExtensions
    {
        public static IEnumerable<T> Query<T>(this IDbConnection cnn, QueryObject queryObject, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
        {
            return cnn.Query<T>(queryObject.SqlString, queryObject.Parameters, transaction, buffered, commandTimeout, commandType);
        }
                
        public static int Execute(this IDbConnection cnn, QueryObject queryObject, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return cnn.Execute(queryObject.SqlString, queryObject.Parameters, transaction, commandTimeout, commandType);
        }
    }
}
