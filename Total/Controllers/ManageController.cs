using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Total.Models;

namespace Total.Controllers
{
    public class ManageController : Controller
    {
        private IUserReposity reposity;

        public ManageController(IUserReposity reposity)
        {
            this.reposity = reposity;
        }

        public void ChangeOldName(string oldName, string newName)
        {
            reposity.GetUser(oldName).Name = newName;
            reposity.SubmitChange();
        }
        
        public IUserReposity Reposity
        {
            get => reposity;
        }


        // GET: Manage
        public ActionResult Index()
        {
            return View();
        }
    }
}