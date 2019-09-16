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
        public ActionResult Index(string category, string subcategory)
        {

            List<tblCategory> categories = new List<tblCategory>(this.repository.GetAllCategories().ToList());
            ViewData["Categories"] = categories;
            if (category != null && category != String.Empty)
            {
                ViewBag.Category = category;
                List<tblSubCategory> subCategories = new List<tblSubCategory>(this.repository.GetSubCategoriesByCategoryName(category).ToList());
                ViewData["SubCategories"] = subCategories;

                if (subcategory != null && subcategory != String.Empty)
                {
                    ViewBag.SubCategory = subcategory;
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult Index(string category, string subcategory, string search)
        {
            return RedirectToRoute("Product", new
            {
                category = category,
                subcategory = subcategory,
                search = search
            });
        }
    }
}