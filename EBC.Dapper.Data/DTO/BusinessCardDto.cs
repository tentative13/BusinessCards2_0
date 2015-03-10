using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBC.DapperData.Dto
{
    public class BusinessCardDto
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime ChangedDate { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Position { get; set; }
        public byte[] CompanyLogo { get; set; }
        public string KeyWords { get; set; }
        public string WebSite { get; set; }
        public byte[] BusinessDemo { get; set; }
        public int Persona_ID { get; set; }

        
    }
}
