using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Total.Models;

namespace UnitTestProject
{
    class FakeReposity:IUserReposity
    {
        List<User> userList=new List<User>();
        private bool submitChange = false;

        public bool DidSubmitChange
        {
            get => submitChange;
        }

        public void Add(params User[] users)
        {
            foreach (var user in users)
            {
                userList.Add(user);
            }
        }

        public User GetUser(string name)
        {
            return userList.Find(m => m.Name == name);
        }

        public void SubmitChange()
        {
            submitChange = true;
        }
    }
}
