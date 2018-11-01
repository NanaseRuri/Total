using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Total.Models.Home
{
    public class Guest
    {
        [Required(ErrorMessage = "Please enter your name")]
        [RegularExpression(@"^\w+\s*\w*$",ErrorMessage = "Please enter a correct name")]
        public string Name { get; set; }
        
        [Required]
        [RegularExpression(@"^\d{11}$",ErrorMessage = "Please enter a correct number")]
        public string Phone { get; set; }

        [Required]
        [RegularExpression(@"^.+@.+\..+",ErrorMessage = "Please enter a correct mail")]
        public string Mail { get; set; }

        [Required]
        public bool? WillAttend { get; set; }
    }
}