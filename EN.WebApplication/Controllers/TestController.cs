using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EN.WebApplication.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult SampleTest()
        {
            return View();
        }

        public ActionResult TakeOnlineTest()
        {
            return View();
        }
    }
}