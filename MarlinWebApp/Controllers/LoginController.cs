using MarlinApp.Data;
using MarlinWebApp.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarlinWebApp.Controllers
{
    public class LoginController : Controller
    {
        public MarlinRepository repository;

        public LoginController()
        {
            repository = new MarlinRepository(new MarlinApp.Data.MarlinAppEntities());
        }

        public LoginController(MarlinRepository repository)
        {
            this.repository = repository;
        }
        
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string username, string password)
        {
            tblUser user = repository.GetUserByName(username);
            if (user != null && password.Equals(user.User_Password))
            {

            } else
            {
                ViewBag.errorMessage = "The username or password you have entered is invalid.";
                return View("Index");
            }
            return Content($"Hello {user.User_Id}, {user.User_Password}"); ;
            /*var _admin = db.Admins.Where(s => s.Email == admin.Email);
            if (_admin.Any())
            {
                if (_admin.Where(s => s.Password == admin.Password).Any())
                {

                    return Json(new { status = true, message = "Login Successfull!" });
                }
                else
                {
                    return Json(new { status = false, message = "Invalid Password!" });
                }
            }
            else
            {
                return Json(new { status = false, message = "Invalid Email!" });
            }*/
        }
    }
}