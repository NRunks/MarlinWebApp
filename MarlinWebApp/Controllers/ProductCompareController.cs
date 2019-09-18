using MarlinApp.Data;
using MarlinWebApp.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarlinWebApp.Controllers
{
    public class ProductCompareController : Controller
    {

        public MarlinRepository repository;
        public ProductCompareController()
        {
            this.repository = new MarlinRepository(new MarlinEntities3());
        }

        public ProductCompareController(MarlinRepository repository)
        {
            this.repository = repository;
        }
        // GET: ProductCompare
        [HttpGet]
        public ActionResult Index(string products)
        {
            if (products != null && products != String.Empty)
            {
                string[] tempArray = products.Split(',');
                int[] productIDArray = new int[tempArray.Length];
                int i = 0;
                for (int j = 0; j < tempArray.Length; j++)
                {
                    if (Int32.TryParse(tempArray[j], out i))
                    {
                        productIDArray[j] = i;
                    }
                    else
                    {
                        productIDArray[j] = -1;
                    }
                }
                List<tblProduct> productList = new List<tblProduct>(this.repository.GetMultipleProductsByID(productIDArray));
                ViewBag.Products = productList;
            }
            return View();
        }
    }
}