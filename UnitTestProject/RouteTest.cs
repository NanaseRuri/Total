using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Total;

namespace UnitTestProject
{
    [TestClass]
    public class RouteTest
    {
        private HttpContextBase CreateHttpContext(string targetUrl = null,
                                                  string httpMethod = "GET")
        {
            // create the mock request 
            Mock<HttpRequestBase> mockRequest = new Mock<HttpRequestBase>();
            mockRequest.Setup(m => m.AppRelativeCurrentExecutionFilePath)
                .Returns(targetUrl);
            mockRequest.Setup(m => m.HttpMethod).Returns(httpMethod);

            // create the mock response
            Mock<HttpResponseBase> mockResponse = new Mock<HttpResponseBase>();
            mockResponse.Setup(m => m.ApplyAppPathModifier(
                It.IsAny<string>())).Returns<string>(s => s);

            // create the mock context, using the request and response
            Mock<HttpContextBase> mockContext = new Mock<HttpContextBase>();
            mockContext.Setup(m => m.Request).Returns(mockRequest.Object);
            mockContext.Setup(m => m.Response).Returns(mockResponse.Object);

            // return the mocked context
            return mockContext.Object;
        }

        private void TestRouteMatch(string url, string controller, string action,
            object routeProperties = null, string httpMethod = "GET")
        {

            // Arrange
            RouteCollection routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);
            // Act - process the route
            RouteData result
                = routes.GetRouteData(CreateHttpContext(url, httpMethod));
            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(TestIncomingRouteResult(result, controller,
                action, routeProperties));
        }

        private bool TestIncomingRouteResult(RouteData routeResult,
            string controller, string action, object propertySet = null)
        {

            Func<object, object, bool> valCompare = (v1, v2) =>
            {
                return StringComparer.InvariantCultureIgnoreCase
                    .Compare(v1, v2) == 0;
            };

            bool result = valCompare(routeResult.Values["controller"], controller)
                && valCompare(routeResult.Values["action"], action);

            if (propertySet != null)
            {
                PropertyInfo[] propInfo = propertySet.GetType().GetProperties();
                foreach (PropertyInfo pi in propInfo)
                {
                    if (!(routeResult.Values.ContainsKey(pi.Name)
                            && valCompare(routeResult.Values[pi.Name],
                            pi.GetValue(propertySet, null))))
                    {

                        result = false;
                        break;
                    }
                }
            }
            return result;
        }

        private void TestRouteFail(string url)
        {
            // Arrange
            RouteCollection routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);
            // Act - process the route
            RouteData result = routes.GetRouteData(CreateHttpContext(url));
            // Assert
            Assert.IsTrue(result == null || result.Route == null);
        }

        [TestMethod]
        public void TestIncomingRoutes()
        {
            //TestRouteMatch("~/Admin/Index","Admin","Index");

            //TestRouteMatch("~/One/Two","One","Two");

            //TestRouteFail("~/Admin/Index/Segment");
            ////TestRouteFail("~/Admin");

            //TestRouteMatch("~/","Home","Index");
            //TestRouteMatch("~/Customer","Customer","Index");
            //TestRouteMatch("~/Customer/List","Customer","List");
            //TestRouteFail("~/Customer/List/All");
            //TestRouteMatch("~/Shop/Index","Home","Index");

            //TestRouteMatch("~/","Home","Index",new{id="DefaultId"});
            //TestRouteMatch("~/Customer","Customer","Index",new{id="DefaultId"});
            //TestRouteMatch("~/Customer/List","Customer","List",new{id="DefaultId"});
            //TestRouteMatch("~/Customer/List/All","Customer","List",new{id="All"});
            //TestRouteFail("~Customer/List/All/Delete");

            //TestRouteMatch("~/","Home","Index");
            //TestRouteMatch("~/Customer","Customer","Index");
            //TestRouteMatch("~/Customer/List","Customer","List");
            //TestRouteMatch("~/Customer/List/All", "Customer", "List", new { id = "All" });
            //TestRouteMatch("~/Customer/List/All/Delete/Perm","Customer","List",new{id="All",catchall="Delete/Perm"});

            TestRouteMatch("~/", "Home", "Index");
            TestRouteMatch("~/Home", "Home", "Index");
            TestRouteMatch("~/Home/About", "Home", "About");
            TestRouteMatch("~/Home/About/All", "Home", "About", new { id = "All" });
            TestRouteMatch("~/Home/About/All/Delete/Perm", "Home", "About", new { id = "All", catchall = "Delete/Perm" });

            TestRouteMatch("~/Home/About/MyId", "Home", "About", new { id = "MyId" });
            TestRouteMatch("~/Home/About/MyId/More/Segments", "Home", "About", new { id = "MyId", catchall = "More/Segments" });

            TestRouteFail("~Regular/Account/Index");
            TestRouteFail("~Regular/Account/About");

        }

    }
}
