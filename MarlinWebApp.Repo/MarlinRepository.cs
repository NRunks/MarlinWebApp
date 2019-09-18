using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarlinApp.Data;

namespace MarlinWebApp.Repo
{
    public class MarlinRepository : IStoreRepository, IDisposable
    {
        private MarlinEntities3 context;

        public MarlinRepository(MarlinEntities3 context)
        {
            this.context = context;
        }

        public void DeleteProduct(int productID)
        {
            tblProduct product = this.context.tblProducts.Find(productID);
            this.context.tblProducts.Remove(product);
        }

        public tblManufacturer GetManufacturerByID(int manufacturerID)
        {
            return this.context.tblManufacturers.Find(manufacturerID);
        }

        public tblManufacturer_tblProduct GetManufacturerAndProductByManufacturerID(int manufacturerID)
        {
            return this.context.tblManufacturer_tblProduct.Find(manufacturerID);
        }

        public tblManufacturer_tblProduct GetManufacturerAndProductByProductID(int productID)
        {
            return this.context.tblManufacturer_tblProduct.Find(productID);
        }

        public tblProduct GetProductByID(int productId)
        {
            return this.context.tblProducts.Find(productId);
        }

        public IEnumerable<tblProduct> GetAllProducts()
        {
            return this.context.tblProducts.ToList();
        }

        public IEnumerable<tblProduct> GetMultipleProductsByID(int[] IDs)
        {
            var query = from p in this.context.tblProducts
            where IDs.Contains(p.Product_ID)
            select p;
            return query.ToList();
        }

        public tblUser GetUserByName(string username)
        {
            return this.context.tblUsers.Find(username);
        }

        public IEnumerable<tblCategory> GetAllCategories()
        {
            return this.context.tblCategories.ToList();
        }

        public IEnumerable<tblSubCategory> GetSubCategoriesByCategoryName(string categoryName)
        {
            var query = this.context.tblCategories.First(c => c.Category_Name.Equals(categoryName));
            if (query != null)
            {
                return (from s in this.context.tblSubCategories where s.Category_ID == query.Category_ID select s).ToList();
            }
            else return null;
        }

        public void InsertProducts(List<tblProduct> products)
        {
            this.context.tblProducts.AddRange(products);
        }

        public void Save()
        {
            this.context.SaveChanges();
        }

        public void UpdateProduct(tblProduct product)
        {
            this.context.Entry(product).State = EntityState.Modified;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
