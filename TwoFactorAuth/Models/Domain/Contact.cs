
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Contact
    {
        public int ID { get; set; }
        public DateTime Created { get; set; }
        public DateTime ChangedDate { get; set; }

        public virtual ICollection<Group> Groups { get; set; }
        public virtual Persona Persona { get; set; }
    }
}
