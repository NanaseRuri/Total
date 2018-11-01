using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Total.Controllers;
using Total.Models;

namespace UnitTestProject
{
    [TestClass]
    public class Total
    {
        [TestMethod]
        public void TestUserReposity()
        {
            FakeReposity fakeReposity=new FakeReposity();
            ManageController target=new ManageController(fakeReposity);
            target.Reposity.Add(new []
            {
                new User(){Name = "Li"}, 
                new User(){Name = "Jing"}, 
                new User(){Name = "Yi"}
            });
            string newName = "Lin";
            User user = fakeReposity.GetUser("Li");
            target.ChangeOldName("Li",newName);
            Assert.AreEqual(newName, user.Name);
            Assert.IsTrue(fakeReposity.DidSubmitChange);

            user = fakeReposity.GetUser("Fuck");
            Assert.IsNull(user);

            user = fakeReposity.GetUser("Jing");
            Assert.IsNotNull(user);

        }
    }
}
