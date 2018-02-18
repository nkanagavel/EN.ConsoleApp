using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EN.WebApplication.Controllers;
using System.Web.Mvc;

namespace EN.UnitTestProject.Controllers
{
    /// <summary>
    /// Summary description for HomeControllerTest
    /// </summary>
    [TestClass]
    public class HomeControllerTest
    {
        public HomeControllerTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestMethodContact()
        {
            var homeController = new HomeController();
            var actual = homeController.Contact() as ViewResult;
            var expected = "Contact";
            Assert.AreEqual(expected, actual.ViewName);
        }

        [TestMethod]
        public void ContactViewBagTest()
        {
            var homeController = new HomeController();
            ViewResult actual = homeController.Contact() as ViewResult;
            string expected = "ContactView";
            //Assert.IsNotNull(actual.ViewBag.Message);
            Assert.AreEqual(expected, actual.ViewBag.Message);
        }

        [TestMethod]
        public void ContactViewDataTest()
        {
            var homeController = new HomeController();
            ViewResult actual = homeController.Contact() as ViewResult;
            string expected = "messageData";
            //Assert.IsNotNull(actual.ViewBag.Message);
            Assert.AreEqual(expected,(string)actual.ViewData["message"]);
        }
    }
}
