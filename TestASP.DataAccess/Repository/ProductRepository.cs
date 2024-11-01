using BookASP.DataAccess.data;
using BookASP.DataAccess.Repository.IRepository;
using BookASP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookASP.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void update(Product product)
        {
 
            var objform = _db.Products.FirstOrDefault(u => u.Id == product.Id);
            if (objform != null)
            {
                objform.ISBN = product.ISBN;
                objform.ListPrice = product.ListPrice;
                objform.Price = product.Price;
                objform.Price50 = product.Price50;
                objform.Price100 = product.Price100;
                objform.Description= product.Description;
                objform.CategoryId = product.CategoryId;
                objform.Author = product.Author;
                objform.Title = product.Title;
                if(product.ImageUrl != null && product.ImageUrl != "")
                {
                    objform.ImageUrl = product.ImageUrl;
                }

            }

        }
    }
}
