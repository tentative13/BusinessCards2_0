using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBC.DapperData.Dto
{
    public class ContactDto
    {
        public int Id { get; set; }

        public DateTime Created { get; set; }
        public DateTime ChangedDate { get; set; }
        public int Persona_ID { get; set; }
    }
}
