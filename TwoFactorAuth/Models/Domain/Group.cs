using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Group
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual Contact Contacts { get; set; }
    }
}
