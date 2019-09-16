using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MarlinApp.Data;
using MarlinWebApp.Repo;

namespace MarlinWebApp.Controllers
{
    public class ProductController : Controller
    {
        public MarlinRepository repository;

        public ProductController()
        {
            this.repository = new MarlinRepository(new MarlinEntities3());
        }

        public ProductController(MarlinRepository repository)
        {
            this.repository = repository;
        }
        // GET: Product
        [HttpGet]
        public ActionResult Index()
        {
            string category = Request.QueryString["category"];
            string subcategory = Request.QueryString["subcategory"];
            string search = Request.QueryString["search"];
            ViewData["Category"] = category;
            ViewData["SubCategory"] = subcategory;
            ViewData["Search"] = search;
            if ((category == null || category == String.Empty) || (subcategory == null || subcategory == String.Empty) || (search == null || search == String.Empty)) {
                //return RedirectToRoute("Invalid");  <----- Remember to uncomment
            }
            return View();
        }
        public ActionResult ProductSummary()
        {
            return View();
        }
        public ActionResult ProductDetails()
        {
            return View();
        }
        public ActionResult ProductDocumentation()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
       
    }
}