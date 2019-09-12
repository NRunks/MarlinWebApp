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
        tblUser GetUserByID(int userId);
        IEnumerable<tblProduct> GetProducts();
        tblProduct GetProductByID(int productId);
        tblManufacturer GetProductByManufacturerID(int manufacturerID);
        void InsertProducts(List<tblProduct> products);
        void DeleteProduct(int productID);
        void UpdateProduct(tblProduct product);
        void Save();
    }
}
