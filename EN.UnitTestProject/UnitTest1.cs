using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EN.WebApplication.Controllers;
using System.Web.Mvc;

namespace EN.UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var defaultController = new DefaultController();
            var actual = defaultController.Index() as ViewResult;
            var expected = "Index";
            Assert.AreEqual(expected, actual.ViewName, "View Name is not correct");
        }

        [TestMethod]
        public void TestUserController()
        {
            var user = new LearningController();

        }
    }
}
