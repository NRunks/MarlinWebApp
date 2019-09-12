using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarlinApp.Data;

namespace MarlinWebApp.Repo
{
    class MarlinRepository : IStoreRepository, IDisposable
    {
        private MarlinEntities context;

        public MarlinRepository(MarlinEntities context)
        {
            this.context = context;
        }

        public void DeleteProduct(int productID)
        {
            tblProduct product = this.context.tblProducts.Find(productID);
            this.context.tblProducts.Remove(product);
        }

        public tblManufacturer GetProductByManufacturerID(int manufacturerID)
        {
            return this.context.tblManufacturers.Find(manufacturerID);
        }

        public tblProduct GetProductByID(int productId)
        {
            return this.context.tblProducts.Find(productId);
        }

        public IEnumerable<tblProduct> GetProducts()
        {
            return this.context.tblProducts.ToList();
        }

        public tblUser GetUserByID(int userId)
        {
            return this.context.tblUsers.Find(userId);
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
