using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Address
    {
        [ScaffoldColumn(false)]
        public int ID { get; set; }

        // [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        public string Contry { get; set; }

        //  [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        public string City { get; set; }


        public string Street { get; set; }


        public string Building { get; set; }
        public string Apartment { get; set; }

        public string PostIndex { get; set; }

        public virtual Persona Persona { get; set; }
    }
}
