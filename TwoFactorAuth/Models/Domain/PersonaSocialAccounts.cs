using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class SocialAccounts
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public virtual Persona Persona { get; set; }
    }
}
