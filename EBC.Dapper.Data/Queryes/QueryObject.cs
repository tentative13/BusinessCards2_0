using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBC.DapperData
{
    public class QueryObject
    {
        public QueryObject(string sql)
        {
            if (string.IsNullOrEmpty(sql))
                throw new ArgumentNullException("sql");

            SqlString = sql;
        }
                
        public QueryObject(string sql, object queryParams)
            : this(sql)
        {
            Parameters = queryParams;
        }
            
        public string SqlString { get; private set; }
        
        public object Parameters { get; private set; }
    }
}
