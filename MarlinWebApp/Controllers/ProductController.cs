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
            if ((category == null || category == String.Empty) || (subcategory == null || subcategory == String.Empty) || (search == null || search == String.Empty))
            {
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
                if ((isNullOrEmpty(year) || year.Equals(Convert.ToInt32(product.Model_Year))) && (isNullOrEmpty(ram) || ram.Equals(product.RAM)) && (isNullOrEmpty(processor) || processor.Equals(product.Processor_Model)) && (isNullOrEmpty(storage) || storage.Equals(product.Storage_Space)) && (isNullOrEmpty(brand) || brand.Equals(product.Brand)) && (isNullOrEmpty(os) || os.Equals(product.Operating_System)))
                {
                    bool screenMatches = false;
                    bool priceMatches = false;

                    if (!isNullOrEmpty(screen))
                    {
                        switch (screen)
                        {
                            case "xs":
                                if (Convert.ToDouble(product.Screen_Size) < 19.0)
                                    screenMatches = true;
                                break;
                            case "md":
                                if (Convert.ToDouble(product.Screen_Size) >= 19.0
                                    && Convert.ToDouble(product.Screen_Size) <= 22.0)
                                    screenMatches = true;
                                break;
                            case "lg":
                                if (Convert.ToDouble(product.Screen_Size) > 22.0
                                    && Convert.ToDouble(product.Screen_Size) < 27.0)
                                    screenMatches = true;
                                break;
                            case "xl":
                                if (Convert.ToDouble(product.Screen_Size) >= 27.0)
                                    screenMatches = true;
                                break;
                            default:
                                screenMatches = false;
                                break;
                        }
                    }
                    else screenMatches = true;
                    if (!isNullOrEmpty(price))
                    {
                        switch (price)
                        {
                            case "low":
                                if (Convert.ToDouble(product.Price) <= 99.0)
                                    priceMatches = true;
                                break;
                            case "mid":
                                if (Convert.ToDouble(product.Price) > 99.0
                                    && Convert.ToDouble(product.Price) <= 399.0)
                                    priceMatches = true;
                                break;
                            case "high":
                                if (Convert.ToDouble(product.Price) > 399.0
                                    && Convert.ToDouble(product.Price) <= 799.0)
                                    priceMatches = true;
                                break;
                            case "very-high":
                                if (Convert.ToDouble(product.Price) > 799.0)
                                    priceMatches = true;
                                break;
                            default:
                                priceMatches = false;
                                break;
                        }
                    }
                    else priceMatches = true;
                    if (screenMatches && priceMatches)
                    {
                        productList.Add(product);
                    }
                }
            }
            ViewBag.Products = productList;

            ViewData["Year"] = year;
            ViewData["Price"] = price;
            ViewData["Screen"] = screen;
            ViewData["RAM"] = ram;
            ViewData["Processor"] = processor;
            ViewData["Storage"] = storage;
            ViewData["Brand"] = brand;
            ViewData["OS"] = os;
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