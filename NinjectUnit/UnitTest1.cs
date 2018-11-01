using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Total.Models.NinjectTest;

namespace NinjectUnit
{
    [TestClass]
    public class UnitTest1
    {
        IDiscountHelper GetTestObject()
        {
            return new MinimumDiscount();
        }

        [TestMethod]
        public void Discount_MoreThan_100()
        {
            IDiscountHelper target = GetTestObject();
            decimal total = 200;
            decimal result = target.ApplyDiscount(total);
            Assert.AreEqual(total*0.9m,result,"Error");
        }

        [TestMethod]
        public void Discount_Between_10_And_100()
        {
            IDiscountHelper target = GetTestObject();
            decimal total = 95;
            decimal result = target.ApplyDiscount(total);
            Assert.AreEqual(total-5,result);
            total = 90;
            result = target.ApplyDiscount(total);
            //Assert.AreEqual(total,result,"90 Error");
            Assert.AreEqual(total-5,result,"90 Error");
        }

        [TestMethod]
        public void Discount_LessThan_10()
        {
            IDiscountHelper target = GetTestObject();
            decimal total = 5;
            decimal result = target.ApplyDiscount(total);
            Assert.AreEqual(total,result);
        }

        [TestMethod]
        public void ErrorInput()
        {
            IDiscountHelper target = GetTestObject();
            decimal total = -5;
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => target.ApplyDiscount(total));

        }



        
    }
}
