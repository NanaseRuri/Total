using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Total.Models.MetaData;

namespace Total.Models.HelperMethods
{
    //[MetadataType(typeof(PersonMetadata))]
    public partial class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Address HomeAddress { get; set; }
        public bool IsApproved { get; set; }
        //[UIHint("Enum")]
        public Role Role { get; set; }
    }
}