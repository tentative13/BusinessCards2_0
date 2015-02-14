
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EBCardsMVC.Models.Domain
{
    public class BusinessCardsTo
    {
        [ScaffoldColumn(false)]
        public int ID { get; set; }
        public virtual BusinessCard BusinessCard { get; set; }
        public virtual Persona PersonaOwner { get; set; }
        public virtual Persona ShareWith { get; set; }
    }
}