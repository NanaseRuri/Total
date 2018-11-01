using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Total.Models.ControllerExtensibility
{
    public class RemoteTask
    {
        public string Remote()
        {
            Thread.Sleep(2000);
            return "It's the remote method";
        }

        public async Task<string> RemoteAsync()
        {            
            return await Task<string>.Factory.StartNew((() =>
            {
                Thread.Sleep(2000);
                return "It's the async task from remoteAsync";
            }));
        }
    }
}