using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Total.Models.SinglePageApp;

namespace Total.Controllers.SinglePageApp
{
    public class SinglePageAppController : Controller
    {
        ReservationRepository repo = ReservationRepository.Current;

        public ActionResult IndexWithoutModel()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View(repo.GetAll);
        }

        public ActionResult Add(Reservation addItem)
        {
            if (ModelState.IsValid)
            {
                repo.Add(addItem);
                return RedirectToAction("Index");
            }

            return View("Index");
        }

        public ActionResult Remove(int id)
        {
            repo.Remove(id);
            return RedirectToAction("Index");
        }

        public ActionResult Update(Reservation updateTarget)
        {
            {
                if (ModelState.IsValid && repo.Update(updateTarget))
                {
                    return RedirectToAction("Index");
                }

                return View("Index");
            }
        }

    }
}