using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBC.Dapper.Data
{
    public interface IConnectionFactory 
    {
        IDbConnection Create();
    }
}
