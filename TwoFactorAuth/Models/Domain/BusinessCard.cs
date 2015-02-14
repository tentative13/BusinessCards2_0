using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EBCardsMVC.Models.Domain
{
    public class BusinessCard
    {
        [ScaffoldColumn(false)]
        public int ID { get; set; }
        [ScaffoldColumn(false)]
        public DateTime Created { get; set; }
        [ScaffoldColumn(false)]
        public DateTime ChangedDate { get; set; }

        [Required]
        public string CompanyName { get; set; }


        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Position { get; set; }
        public byte[] CompanyLogo { get; set; }
        public string[] KeyWords { get; set; }
        public string WebSite { get; set; }
        public byte[] BusinessDemo { get; set; }


        public virtual ICollection<Address> Address { get; set; }
    }
}

