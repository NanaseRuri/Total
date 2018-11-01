using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Total.Models;
using Total.Models.NinjectTest;

namespace NinjectUnit
{
    /// <summary>
    ///
    ///
    /// Test 的摘要说明
    /// </summary>
    [TestClass]
    public class MockTest
    {
        private Product[] products = {
            new Product {Name = "Kayak", Category = "Watersports", Price = 275M},
            new Product {Name = "Lifejacket", Category = "Watersports", Price = 48.95M},
            new Product {Name = "Soccer ball", Category = "Soccer", Price = 19.50M},
            new Product {Name = "Corner flag", Category = "Soccer", Price = 34.95M}
        };

        [TestMethod]
        public void Sum_Products_Correctly()
        {
            Mock<IDiscountHelper> mock = new Mock<IDiscountHelper>();
            mock.Setup(m => m.ApplyDiscount(It.IsAny<decimal>())).Returns<decimal>(total => total);

            var target = new LinqValueCalculator(mock.Object);
            var result = target.ValueProduct(products);
            Assert.AreEqual(products.Sum(p=>p.Price),result);

        }

        Product[] CreateProducts(decimal value)
        {
            return new[] {new Product() {Price = value}};
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentOutOfRangeException))]
        public void DifferentDiscount()
        {
            Mock<IDiscountHelper> mock = new Mock<IDiscountHelper>();
            mock.Setup(m => m.ApplyDiscount(It.IsAny<decimal>())).Returns<decimal>(total => total);
            mock.Setup(m => m.ApplyDiscount(It.Is<decimal>(v => v <= 0))).Throws(new ArgumentOutOfRangeException());
            mock.Setup(m => m.ApplyDiscount(It.IsInRange<decimal>(10, 100, Range.Inclusive)))
                .Returns<decimal>(total => total - 5);
            mock.Setup(m => m.ApplyDiscount(It.Is<decimal>(v => v > 100))).Returns<decimal>(total => 0.9m * total);
            var target=new LinqValueCalculator(mock.Object);

            decimal FiveDollarDiscount = target.ValueProduct(CreateProducts(5));
            decimal TenDollarDiscount = target.ValueProduct(CreateProducts(10));
            decimal FiftyDollarDiscount = target.ValueProduct(CreateProducts(50));
            decimal HundredDollarDiscount = target.ValueProduct(CreateProducts(100));
            decimal FiveHundredDollarDiscount = target.ValueProduct(CreateProducts(500));

            Assert.AreEqual(5, FiveDollarDiscount, "$5 Fail");
            Assert.AreEqual(5, TenDollarDiscount, "$10 Fail");
            Assert.AreEqual(45, FiftyDollarDiscount, "$50 Fail");
            Assert.AreEqual(95, HundredDollarDiscount, "$100 Fail");
            Assert.AreEqual(450, FiveHundredDollarDiscount, "$500 Fail");
            target.ValueProduct(CreateProducts(0));
        }
    }
}
