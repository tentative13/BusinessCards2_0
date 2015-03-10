
using EBC.DapperData.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBC.DapperData
{
    public class InsertPersonaSocialAccounts
    {
        public QueryObject Query(PersonaSocialAccountsDto sa)
        {
            return new QueryObject(
                @"INSERT INTO [SocialAccounts]
                       ([Name]
                       ,[Link]
                       ,[Persona_ID])
                 VALUES
                       (@Name
                       ,@Link 
                       ,@Persona_ID)
                  SELECT @@IDENTITY"
                , new {sa.Name, sa.Link, sa.Persona_ID });
        }
    }
}
