using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Total.Models.HelperMethods;
using Total.Models.ModelBinding;

namespace Total.Controllers.ModelBinding
{
    public class ModelBindingController : Controller
    {
        private Person[] personData = {
            new Person {PersonId = 1, FirstName = "Adam", LastName = "Freeman",
                Role = Role.Admin},
            new Person {PersonId = 2, FirstName = "Jacqui", LastName = "Griffyth",
                Role = Role.User},
            new Person {PersonId = 3, FirstName = "John", LastName = "Smith",
                Role = Role.User},
            new Person {PersonId = 4, FirstName = "Anne", LastName = "Jones",
                Role = Role.Guest}
        };

        public ActionResult Index(int id = 1)
        {
            Person person = personData.FirstOrDefault(p => p.PersonId == id);
            return View(person);
        }

        public ActionResult CreatePerson()
        {
            return View(new Person());
        }

        [HttpPost]
        public ActionResult CreatePerson(Person person)
        {
            return View("Index", person);
        }

        public ActionResult AddressSummary(
            [Bind(Prefix = "HomeAddress")] AddressSummary address)
        {
            return View(address);
        }

        public ActionResult Names(string[] names)
        {
            names = names ?? new string[0];
            return View(names);
        }

        //public ActionResult Address()
        //{
        //    IList<AddressSummary> addresses=new List<AddressSummary>();
        //    UpdateModel(addresses,new FormValueProvider(ControllerContext));
        //    return View(addresses);
        //}

        //public ActionResult Address(IList<AddressSummary> addresses)
        //{
        //    addresses = addresses ?? new List<AddressSummary>();
        //    return View(addresses);
        //}

        public ActionResult Address(FormCollection collection)
        {
            IList<AddressSummary> addresses = new List<AddressSummary>();
            //try
            //{
            //    UpdateModel(addresses,collection);
            //}
            //catch (InvalidOperationException e)
            //{
            //    Console.WriteLine(e);                
            //}
            //if (TryUpdateModel(addresses,collection))
            //{

            //}
            //else
            //{

            //}
            UpdateModel(addresses);
            return View(addresses);
        }
    }
}