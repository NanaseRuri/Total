using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Total.Infrastructure.Filters;
using Total.Models.ControllerExtensibility;

namespace Total.Controllers.ControllerExtensibility
{
    public class RemoteController : Controller
    {        
        // GET: Remote
        [TimeAllTake]
        public ActionResult Data()
        {
            RemoteTask task=new RemoteTask();
            string str=task.Remote();
            return View((object)str);
        }

        [TimeAllTake]
        public async Task<ActionResult> DataAsyncByRemote()
        {
            RemoteTask task=new RemoteTask();
            string str = await task.RemoteAsync();
            return View("../Remote/Data", (object) str);
        }

        [TimeAllTake]
        public async Task<ActionResult> DataAsyncLocal()
        {
            string str = await Task<string>.Factory.StartNew((() =>
            {
                Thread.Sleep(2000);
                return "It's the async string from local";
            }));
            return View("../Remote/Data", (object) str);
        }
    }
}