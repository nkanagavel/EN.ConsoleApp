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
    public class UserController : Controller
    {
        private readonly IUser _userRepository;
        public UserController()
        {
            this._userRepository = new UserService();
        }
        public UserController(IUser userRepository)
        {
            this._userRepository = userRepository;
        }

        // GET: User
        public ActionResult RegisterUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterUser(User user)
        {
            var response = 1;
            if (user.Id > 0)
                response = this._userRepository.UpdateUser(user);
            else
                response = this._userRepository.RegisterUser(user);
            var result = response >= 1 ? "success" : "failed";
            return Json(new { result = result });
        }

        [HttpGet]
        public ActionResult GetUsers()
        {
            var response = this._userRepository.GetUsers();
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetUserById(int userId)
        {
            var response = this._userRepository.GetUserById(userId);
            return Json(response);
        }
    }
}