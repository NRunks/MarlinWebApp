using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarlinWebApp.Controllers
{
    public class ProductCompareController : Controller
    {
        // GET: ProductCompare
        [HttpGet]
        public ActionResult Index(string products)
        {
            return View();
        }
    }
}