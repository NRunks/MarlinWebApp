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

        [HttpPost]
        public ActionResult Index(string year, string price, string screen, 
            string ram, string processor, string storage, string brand, string os)
        {
            List<tblProduct> products = new List<tblProduct>(this.repository.GetAllProducts());
            List<tblProduct> productList = new List<tblProduct>();


            foreach (tblProduct product in products)
            {
                if ((isNullOrEmpty(year) || year.Equals(Convert.ToInt32(product.Model_Year))) && (isNullOrEmpty(price) || price.Equals(product.Price)) &&
                    (isNullOrEmpty(screen) || screen.Equals(product.Screen_Size)) && (isNullOrEmpty(ram) || ram.Equals(product.RAM))
                    && (isNullOrEmpty(processor) || processor.Equals(product.Processor_Model)) && (isNullOrEmpty(storage) || storage.Equals(product.Storage_Space)) && (isNullOrEmpty(brand) || brand.Equals(product.Brand)) && (isNullOrEmpty(os) || os.Equals(product.Operating_System))) 
                {
                    productList.Add(product);
                }
            }
            ViewBag.Products = productList;
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
        public ActionResult Compare()
        {
            return View();
        }

        public bool isNullOrEmpty(string s)
        {
            return (s == null || s == String.Empty);
        }

    }
}