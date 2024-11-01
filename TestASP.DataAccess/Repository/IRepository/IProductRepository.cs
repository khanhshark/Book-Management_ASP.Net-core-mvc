using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BookASP.Model;


namespace BookASP.DataAccess.Repository.IRepository
{
	public interface IProductRepository : IRepository<Product>
	{
		void update(Product product);
		

	}
}
