using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Total.Models.MetaData
{
    [DisplayName("A PersonMetadata")]
    public partial class PersonMetadata
    {
        [HiddenInput(DisplayValue = false)]
        public int PersonId { get; set; }

        [UIHint("MultilineText")]
        [DisplayName("First")]
        public string FirstName { get; set; }

        [DisplayName("Last")]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Birth")]
        public DateTime BirthDate { get; set; }
    }
}