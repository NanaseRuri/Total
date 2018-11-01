using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Total.Models.HelperMethods;

namespace Total.Controllers.HelperMethod.Ajax
{
    public class AjaxPeopleController : Controller
    {

        private Person[] personData = {
            new Person {FirstName = "Adam", LastName = "Freeman", Role = Role.Admin},
            new Person {FirstName = "Jacqui", LastName = "Griffyth", Role = Role.User},
            new Person {FirstName = "John", LastName = "Smith", Role = Role.User},
            new Person {FirstName = "Anne", LastName = "Jones", Role = Role.Guest}
        };

        // GET: AjaxPeople
        
        public ActionResult GetPeopleData(string roleName="All")
        {
            IEnumerable<Person> data = personData;
            if (roleName != "All")
            {
                Role selected = (Role)Enum.Parse(typeof(Role), roleName);
                data = personData.Where(p => p.Role == selected);
            }
            if (Request.IsAjaxRequest())
            {
                var formattedData = data.Select(p => new {
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Role = Enum.GetName(typeof(Role), p.Role)
                });
                return Json(formattedData, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return PartialView(data);
            }
        }

        public ActionResult GetPeople(string roleName="All")
        {
            return View((object)roleName);
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}