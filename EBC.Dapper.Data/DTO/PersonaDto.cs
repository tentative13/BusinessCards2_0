using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBC.DapperData.Dto
{
    public class PersonaDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public byte[] Picture { get; set; }
        public string WebSite { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime Created { get; set; }
        public DateTime Changed { get; set; }

        public BusinessCardDto BusinessCard { get; set; }
    }
}
