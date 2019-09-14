using MarlinApp.Data;
using MarlinWebApp.Repo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarlinWebApp.Controllers
{
    public class SearchController : Controller
    {
        public MarlinRepository repository;

        public SearchController()
        {
            this.repository = new MarlinRepository(new MarlinEntities3());
        }

        public SearchController(MarlinRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            List<tblCategory> categories = new List<tblCategory>(this.repository.GetAllCategories().ToList());
            ViewData["Categories"] = categories;
            return View();
        }
    }
}