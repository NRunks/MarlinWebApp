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
            repository = new MarlinRepository(new MarlinApp.Data.MarlinEntities3());
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
            if (user == null || !password.Equals(user.User_Password))
            {
                ViewBag.errorMessage = "The username or password you have entered is invalid.";
                return View("Index");
            } else
            {
                return RedirectToAction("Index", "Search");
            }
        }
    }
}

