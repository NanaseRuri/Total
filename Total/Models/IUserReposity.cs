using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Total.Models
{
    public interface IUserReposity
    {
        void Add(params User[] users);
        User GetUser(string name);
        void SubmitChange();
    }
}