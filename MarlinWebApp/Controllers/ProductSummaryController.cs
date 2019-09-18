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
        public ActionResult Index(MarlinApp.Data.tblProduct product, string Category_Name, string SubCategory_Name)
        {

            if (product.Product_ID == 0)
            {
                return RedirectToRoute("Invalid");
            }
            tblProduct tempProduct = this.repository.GetProductByID(product.Product_ID);
            //         tblManufacturer tempManufacturer = this.repository.GetManufacturerByID(1);
            //         tblManufacturer_tblProduct ManuProduct = this.repository.GetManufacturerAndProductByProductID(product.Product_ID);
            //        ViewBag.Manufacturer = tempManufacturer;

            ViewBag.Product = tempProduct;
            ViewData["Category"] = Category_Name;
            ViewData["Subcategory"] = SubCategory_Name;
            return View();
        }
    }
}