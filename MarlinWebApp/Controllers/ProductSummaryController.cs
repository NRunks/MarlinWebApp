using MarlinApp.Data;
using MarlinWebApp.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarlinWebApp.Controllers
{
    public class ProductSummaryController : Controller
    {
        public MarlinRepository repository;

        public ProductSummaryController()
        {
            this.repository = new MarlinRepository(new MarlinEntities3());
        }

        public ProductSummaryController(MarlinRepository repository)
        {
            this.repository = repository;
        }
        // GET: ProductSummary
        public ActionResult Index(MarlinApp.Data.tblProduct product)
        {
            tblProduct tempProduct = this.repository.GetProductByID(product.Product_ID);
            ViewBag.Product = tempProduct;
            return View(product);
        }
    }
}