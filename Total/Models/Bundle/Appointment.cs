using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Total.Models.Bundle
{
    public class Appointment
    {
        [Required]
        public string ClientName { get; set; }

        public bool TermsAccepted { get; set; }
    }
}