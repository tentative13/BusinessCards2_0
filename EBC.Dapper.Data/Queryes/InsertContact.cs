using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EBC.DapperData.Dto;

namespace EBC.DapperData
{
    public class InsertContact
    {
        public QueryObject Query(ContactDto c)
        {
            return new QueryObject(
                @"INSERT INTO [Contacts]
                       ([Created]
                       ,[ChangedDate]
                       ,[Persona_ID])
                 VALUES
                       (@Created
                       ,@ChangedDate
                       ,@Persona_ID);
                SELECT @@IDENTITY;", new { c.Created, c.ChangedDate, c.Persona_ID }
                );
        }
    }
}
