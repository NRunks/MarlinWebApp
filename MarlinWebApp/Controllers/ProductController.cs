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
            this.repository = new MarlinRepository(new MarlinAppEntities());
        }

        public ProductController(MarlinRepository repository)
        {
            this.repository = repository;
        }
        // GET: Product
        [HttpGet]
        public ActionResult Index()
        {        
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