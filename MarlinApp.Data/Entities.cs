using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarlinApp.Data
{
    public class User
    {
        int userID { get; set; }
        string username { get; set; }
        string password { get; set; }
        string email { get; set; }
        string imageURL { get; set; }
    }

    public class Product
    {
        int productID { get; set; }
        int manufacturerID { get; set; }
        int salesID { get; set; }
        int subcategoryID { get; set; }
        string productName { get; set; }
        string productImage { get; set; }
        string series { get; set; }
        int modelYear { get; set; }
        string model { get; set; }
        string seriesInfo { get; set; }
        int documentID { get; set; }
        string featured { get; set; }
    }

    public class Sales
    {
        int salesID { get; set; }
        string salesName { get; set; }
        string phone { get; set; }
        string email { get; set; }
        string webURL { get; set; }
    }

    public class Category
    {
        int categoryID { get; set; }
        string categoryName { get; set; }
    }

    public class Subcategory
    {
        int subcategoryID { get; set; }
        int categoryID { get; set; }
        string subcategoryName { get; set; }
    }

    public class Manufacturer
    {
        int manufacturerID { get; set; }
        string manufacturerName { get; set; }
        string manufacturerDepartment { get; set; }
        string manufacturerWebnURL { get; set; }
        int userID { get; set; }
    }
}
