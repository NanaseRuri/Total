using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Total.Infrastructure.ModelBinding;

namespace Total.Models.ModelBinding
{
    [ModelBinder(typeof(AddressSummaryBinder))]
    [Bind(Exclude = "Country")]
    public class AddressSummary
    {
        public string City { get; set; }
        public string Country { get; set; }
    }
}