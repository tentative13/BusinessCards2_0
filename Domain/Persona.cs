using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Persona
    {
        [ScaffoldColumn(false)]
        public int ID { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }

        [ScaffoldColumn(false)]
        [DataType(DataType.Upload)]
        public byte[] Picture { get; set; }

        [DataType(DataType.Url)]
        public string WebSite { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Phone { get; set; }

        [ScaffoldColumn(false)]
        public DateTime Created { get; set; }
        [ScaffoldColumn(false)]
        public DateTime Changed { get; set; }

        public virtual ICollection<BusinessCard> BusinessCards { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
        public virtual ICollection<SocialAccounts> SocialAccounts { get; set; }
        public virtual ICollection<Address> Address { get; set; }
    }
}
