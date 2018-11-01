using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Total.Models.ValidationSummary;

namespace Total.Infrastructure.ValidationSummary
{
    public class NoZhouyiOnMondayAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            Appointment appointment = value as Appointment;
            if (appointment == null || string.IsNullOrEmpty(appointment.ClientName) || appointment.Date == null)
            {
                return true;
            }

            return !(appointment.ClientName == "Zhouyi" && appointment.Date.DayOfWeek == DayOfWeek.Monday);
        }

    }
}