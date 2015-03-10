
using EBC.DapperData.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBC.DapperData
{
    public class InsertPersona
    {
        public QueryObject Query(PersonaDto p)
        {
            return new QueryObject(
                @"INSERT INTO [Personas]
                   ([FirstName]
                   ,[LastName]
                   ,[BirthDate]
                   ,[Picture]
                   ,[WebSite]
                   ,[Email]
                   ,[Phone]
                   ,[Created]
                   ,[Changed])
                VALUES
                   (@FirstName
                   ,@LastName
                   ,@BirthDate
                   ,@Picture 
                   ,@WebSite 
                   ,@Email 
                   ,@Phone
                   ,@Created 
                   ,@Changed);
                SELECT @@identity", new { p.FirstName, p.LastName, p.BirthDate, p.Picture, p.WebSite, p.Email, p.Phone, p.Created, p.Changed });
        }
    }
}
