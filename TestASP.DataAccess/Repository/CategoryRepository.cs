using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BookASP.DataAccess.data;
using BookASP.DataAccess.Repository.IRepository;
using BookASP.Model;

namespace BookASP.DataAccess.Repository
{
	public class CategoryRepository : Repository<Category>, ICategoryRepository
	{
		private readonly ApplicationDbContext _db;
		public CategoryRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}
		public void update(Category category)
		{
			_db.Update(category);
		}
	}
}
