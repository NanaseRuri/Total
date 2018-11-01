using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Total.Infrastructure.ModelBinding
{
    public class CountryValueProvider:IValueProvider
    {
        public bool ContainsPrefix(string prefix)
        {
            return prefix.ToLower().Contains("country");
        }

        public ValueProviderResult GetValue(string key)
        {
            if (ContainsPrefix(key))
            {
                return new ValueProviderResult("China","China",CultureInfo.InvariantCulture);
            }

            return null;
        }
    }
}