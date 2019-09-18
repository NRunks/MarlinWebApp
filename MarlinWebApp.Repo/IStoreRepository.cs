using MarlinApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarlinWebApp.Repo
{
    public interface IStoreRepository : IDisposable
    {
        tblUser GetUserByName(string username);
        IEnumerable<tblProduct> GetAllProducts();
        IEnumerable<tblManufacturer> GetAllManufacturers();
        tblProduct GetProductByID(int productId);
        IEnumerable<tblProduct> GetMultipleProductsByID(int[] IDs);
        tblManufacturer GetManufacturerByID(int manufacturerID);
        tblManufacturer_tblProduct GetManufacturerAndProductByManufacturerID(int manufacturerID);
        tblManufacturer_tblProduct GetManufacturerAndProductByProductID(int productID);
        IEnumerable<tblCategory> GetAllCategories();
        IEnumerable<tblSubCategory> GetSubCategoriesByCategoryName(string categoryName);
        void InsertProducts(List<tblProduct> products);
        void DeleteProduct(int productID);
        void UpdateProduct(tblProduct product);
        void Save();
    }
}
