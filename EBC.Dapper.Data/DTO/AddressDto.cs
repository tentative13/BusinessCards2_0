using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBC.DapperData.Dto
{
    public class AddressDto
    {
        public int Id { get; set; }

        public string Contry { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }
        public string PostIndex { get; set; }
        public string Apartment { get; set; }

        public int Persona_ID { get; set; }
        public int BusinessCard_ID { get; set; }
    }
}
