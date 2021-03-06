﻿using Moq;
using NUnit.Framework;
using System;
using System.Reflection;
using System.Web;
using System.Web.Routing;

namespace ReviewsCollector.Web.Tests.Routes
{
    [TestFixture]
    public class RoutesTests
    {
        private HttpContextBase CreateHttpContext(string targetUrl = null, string httpMethod = "GET")
        {
            Mock<HttpRequestBase> requestBaseMock = new Mock<HttpRequestBase>();
            requestBaseMock.Setup(m => m.AppRelativeCurrentExecutionFilePath).Returns("~" + targetUrl);
            requestBaseMock.Setup(m => m.HttpMethod).Returns(httpMethod);

            Mock<HttpResponseBase> responseBaseMock = new Mock<HttpResponseBase>();
            responseBaseMock.Setup(m => m.ApplyAppPathModifier(It.IsAny<string>())).Returns<string>(s => s);

            Mock<HttpContextBase> contextBaseMock = new Mock<HttpContextBase>();
            contextBaseMock.Setup(m => m.Request).Returns(requestBaseMock.Object);
            contextBaseMock.Setup(m => m.Response).Returns(responseBaseMock.Object);

            return contextBaseMock.Object;
        }

        private bool TestIncomingRouteResult(RouteData routeResult, string controller, string action, object propertySet = null)
        {
            Func<object, object, bool> valCompare = (v1, v2) =>
            {
                return StringComparer.InvariantCultureIgnoreCase.Compare(v1, v2) == 0;
            };

            bool result = valCompare(routeResult.Values["controller"], controller) && valCompare(routeResult.Values["action"], action);

            if(propertySet != null)
            {
                PropertyInfo[] propInfo = propertySet.GetType().GetProperties();
                foreach (PropertyInfo pi in propInfo)
                {
                    if (!(routeResult.Values.ContainsKey(pi.Name) && valCompare(routeResult.Values[pi.Name], pi.GetValue(propertySet, null))))
                    {
                        result = false;
                        break;
                    }
                }
            }

            return result;
        }

        private void TestRoutFail(string url)
        {
            RouteCollection routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            RouteData result = routes.GetRouteData(CreateHttpContext(url));

            Assert.IsTrue(result == null || result.Route == null);
        }

        private void TestRouteMatch(string url, string controller, string action, object routeProperties = null, string httpMethod = "GET")
        {
            RouteCollection routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            RouteData result = routes.GetRouteData(CreateHttpContext(url, httpMethod));

            Assert.IsNotNull(result);
            Assert.IsTrue(TestIncomingRouteResult(result, controller, action, routeProperties));
        }
        
        [TestCase]
        public void TestIncomingRoutes()
        {
            TestRouteMatch("/", "Home", "Index");
            TestRouteMatch("/Reviews", "Reviews", "ReviewsList");
        }
    }
}
