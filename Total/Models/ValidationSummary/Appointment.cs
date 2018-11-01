using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Total.Infrastructure.ValidationSummary;

namespace Total.Models.ValidationSummary
{
    [NoZhouyiOnMonday(ErrorMessage = "She can't come")]
    public class Appointment
    //public class Appointment:IValidatableObject
    {
        //[Required(ErrorMessage = "You must set a value here")]
        //[FutureDate(ErrorMessage = "Your appointed time must be in the future")]
        [DataType(DataType.Date)]
        [Remote("RemoteValidate","ValidationSummary")]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(10,MinimumLength = 3)]
        public string ClientName { get; set; }

        [MustBeTrue(ErrorMessage = "Hello?")]
        //[Range(typeof(bool),"true","true",ErrorMessage = "You must confirm the option")]
        public bool TermAccept { get; set; }

        /*
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors=new List<ValidationResult>();
            if (Date <= DateTime.Now) {errors.Add(new ValidationResult("You must provide a value in the future")); }

            if (string.IsNullOrEmpty(ClientName))
            {
                errors.Add(new ValidationResult("ClientName needs a value"));
            }

            if (errors.Count==0&&ClientName=="Zhouyi"&&Date.DayOfWeek==DayOfWeek.Monday)
            {
                errors.Add(new ValidationResult("Zhouyi can appoint on Monday"));
            }

            if (!TermAccept)
            {
                errors.Add(new ValidationResult("You must accept it"));
            }

            return errors;
        }*/
    }
}