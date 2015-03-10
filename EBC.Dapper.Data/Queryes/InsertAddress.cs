
using EBC.DapperData.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBC.DapperData
{
    public class InsertAddress
    {
        public QueryObject Query(AddressDto a)
        {
            return new QueryObject(
            @"INSERT INTO [Addresses]
               ([Contry]
               ,[City]
               ,[Street]
               ,[Building]
               ,[Apartment]
               ,[PostIndex]
               ,[Persona_ID]
               ,[BusinessCard_ID])
            VALUES
               (@Contry
               ,@City
               ,@Street
               ,@Building
               ,@Apartment
               ,@PostIndex
               ,@Persona_ID
               ,@BusinessCard_ID);
            SELECT @@identity;", new {a.Contry, a.City, a.Street, a.Building, a.Apartment, a.PostIndex, a.Persona_ID, a.BusinessCard_ID});
        }
    }

    
}
