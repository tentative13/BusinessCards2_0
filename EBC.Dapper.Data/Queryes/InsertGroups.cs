
using EBC.DapperData.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBC.DapperData
{
    public class InsertGroups
    {
        public QueryObject Query(GroupDto c)
        {
            return new QueryObject(
                @"INSERT INTO [Groups]
                       ([Name]
                       ,[Contacts_ID])
                 VALUES
                       (@Name
                       ,@Contacts_ID)
                SELECT @@IDENTITY;", new {c.Name, c.Contacts_ID }
                );
        }
    }
}
