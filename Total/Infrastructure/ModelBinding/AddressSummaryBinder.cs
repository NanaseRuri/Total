using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Total.Models.ModelBinding;

namespace Total.Infrastructure.ModelBinding
{
    public class AddressSummaryBinder:IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            AddressSummary model = (AddressSummary)bindingContext.Model ?? new AddressSummary();
            model.City = GetValue(bindingContext, "City");
            model.Country = GetValue(bindingContext, "Country");
            return model;
        }

        private string GetValue(ModelBindingContext context, string property)
        {
            property = (context.ModelName == "" ? "" : context.ModelName + ".") + property;
            var value= context.ValueProvider.GetValue(property);
            if (value==null||value.AttemptedValue=="")
            {
                return "<Not Specify>";
            }

            return value.AttemptedValue;
        }
    }
}