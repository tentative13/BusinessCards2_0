
using EBC.DapperData.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBC.DapperData
{
    public class InsertBusinessCard
    {
        public QueryObject Query(BusinessCardDto bc)
        {
            return new QueryObject(@"INSERT INTO [BusinessCards]
           (Created
           ,ChangedDate
           ,CompanyName
           ,Email
           ,Phone
           ,Position
           ,CompanyLogo
           ,WebSite
           ,BusinessDemo
           ,Persona_ID)
     VALUES
           (@Created
           ,@ChangedDate
           ,@CompanyName
           ,@Email
           ,@Phone
           ,@Position
           ,@CompanyLogo
           ,@WebSite
           ,@BusinessDemo
           ,@Persona_ID);
            SELECT @@identity;", new { bc.Created, bc.ChangedDate, bc.CompanyName
                                            , bc.Email, bc.Phone, bc.Position, bc.CompanyLogo, bc.WebSite, bc.BusinessDemo, bc.Persona_ID});
        }
    }
}
