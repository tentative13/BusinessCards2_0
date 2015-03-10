using System;
using System.Data;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EBC.DapperData;
using EBC.DapperData.Dto;

namespace EBC.Data.Tets
{
    [TestClass]
    public class Insert 
    {
        [TestMethod]
        public void InsertPersonaWithBusinessCardWithSocialAccounts()
        {
            using (IDbConnection dbConnection = new TestConnectionFactory().Create())
            {
                var persona = new PersonaDto() { 
                    FirstName = "Dan",
                    LastName = "Gilbert",
                    Changed = DateTime.Now,
                    Created = DateTime.Now,
                    Email = "dg@gmail.com",
                    Phone = "4957896523",
                    Picture = null,
                    WebSite = "dg.web2be.com",
                    BirthDate = DateTime.Now };
                
                var insertPersona = new InsertPersona();
                persona.Id = (int)dbConnection.Query<Int64>(insertPersona.Query(persona)).Single();
                Assert.AreNotEqual(0, persona.Id);

                var insertBusinessCard = new InsertBusinessCard();
                var bc = new BusinessCardDto
                {
                    ChangedDate = DateTime.Now,
                    CompanyName = "SHX",
                    Created = DateTime.Now,
                    Email = "shx@demo.de",
                    KeyWords = "AC",
                    Phone = "214525654568465453213",
                    Position = "CEO",
                    WebSite = "shx.ru",
                    CompanyLogo = new byte[]{123,125,123},
                    BusinessDemo = new byte[]{1,2,3,4,5,6},
                    Persona_ID = persona.Id
                };

                bc.Id = (int)dbConnection.Query<Int64>(insertBusinessCard.Query(bc)).Single();
                Assert.AreNotEqual(0, bc.Id);

                var insertAddress = new InsertAddress();
                var address = new AddressDto()
                {
                    Apartment = "1",
                    Building = "22",
                    BusinessCard_ID = bc.Id,
                    City = "Perm",
                    Contry = "Russia",
                    Persona_ID = persona.Id,
                    PostIndex = "614000",
                    Street = "Lenina"
                };

                address.Id = (int)dbConnection.Query<Int64>(insertAddress.Query(address)).Single();
                Assert.AreNotEqual(0, address.Id);

                var personaSa = new PersonaSocialAccountsDto()
                {
                    Link = "http://web20.ru",
                    Name = "Vkontakte",
                    Persona_ID = persona.Id
                };

                var insertSa = new InsertPersonaSocialAccounts();
                personaSa.Id = (int)dbConnection.Query<Int64>(insertSa.Query(personaSa)).Single();
                Assert.AreNotEqual(0, personaSa.Id);
            }
        }

        [TestMethod]
        public void InsertContactWithGroup()
        {
            using (IDbConnection dbConnection = new TestConnectionFactory().Create())
            { 
                var personaID = 9; //TODO GetPersonaWithMaxId

                var contact = new ContactDto()
                {
                    ChangedDate = DateTime.Now,
                    Created = DateTime.Now,
                    Persona_ID = personaID
                };
                var insertContact = new InsertContact();
                contact.Id = (int)dbConnection.Query<Int64>(insertContact.Query(contact)).Single();
                Assert.AreNotEqual(0, contact.Id);

                var group = new GroupDto() { Name = "Personal", Contacts_ID = contact.Id };
                var insertGroup = new InsertGroups();
                group.Id = (int)dbConnection.Query<Int64>(insertGroup.Query(group)).Single();
                Assert.AreNotEqual(0, group.Id);
            }
        }
    }
}
