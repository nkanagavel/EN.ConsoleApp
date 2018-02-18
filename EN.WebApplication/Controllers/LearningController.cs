using EN.WebApplication.DataAbstraction;
using EN.WebApplication.DataServices;
using EN.WebApplication.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EN.WebApplication.Controllers
{
    public class LearningController : Controller
    {
        private readonly ITest _testRepository;
        private readonly IUser _userRepository;
        public LearningController()
        {
            this._testRepository = new TestService();
            this._userRepository = new UserService();
        }
        public LearningController(ITest testRepository, IUser userRepository)
        {
            this._testRepository = testRepository;
            this._userRepository = userRepository;
        }
        // GET: Learning
        public ActionResult Course()
        {
            return View();
        }

       



        [HttpGet]
        public JsonResult GetModuleQuestions(int moduleId)
        {
            var questions = this._testRepository.GetModuleQuestion();
            return Json(questions, JsonRequestBehavior.AllowGet);

        }
    }
}