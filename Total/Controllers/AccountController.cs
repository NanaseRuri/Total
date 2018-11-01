using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingCartDomain.Abstract;
using Total.Models.SportStore;

namespace Total.Controllers
{
    public class AccountController : Controller
    {
        private IAuthorProvider authorProvider;

        public AccountController(IAuthorProvider authorProvider)
        {
            this.authorProvider = authorProvider;
        }
        
        // GET: Account
        public ViewResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AccountHelper helper,string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (authorProvider.Authenticate(helper.UserName, helper.Password))
                {
                    return Redirect(returnUrl ?? Url.Action("List", "Admin"));
                }
                else
                {
                    ModelState.AddModelError("","Error account or password");
                    return View();
                }
            }
            return View();
        }
    }
}