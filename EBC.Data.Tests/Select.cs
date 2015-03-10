
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using global::Dapper;
using EBC.DapperData;
using EBC.DapperData.Dto;

namespace EBC.Data.Tets
{
    [TestClass]
    public class Select
    {
        [TestMethod]
        public void SelectPersonaDtoAll()
        {
            using (IDbConnection dbConnection = new TestConnectionFactory().Create())
            {
                QueryObject byId = new SelectPersona().ById(14);
                PersonaDto[] data = dbConnection.Query<PersonaDto, BusinessCardDto, PersonaDto>(byId.SqlString, (persona, bc) => { persona.BusinessCard = bc; return persona; }, byId.Parameters).ToArray();
                Assert.AreEqual(1, data.Length);
            }
        }
    }
}
