using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BookASP.DataAccess.Repository.IRepository;
using BookASP.DataAccess.data;
using Microsoft.EntityFrameworkCore;


namespace BookASP.DataAccess.Repository
{
	public class Repository<T> : IRepository<T> where T : class
	{
		private ApplicationDbContext _db;
		internal DbSet<T> dbSet;

	

		public Repository(ApplicationDbContext db)
		{
			_db = db;
			this.dbSet = _db.Set<T>();
		}
			
		public void Add(T entity)
		{
			dbSet.Add(entity);
		}

		public T Get(Expression<Func<T, bool>> filter, String? includeProperties = null)
		{
			IQueryable<T> query = dbSet;
			query = query.Where(filter);
			// Xử lý includeProperties nếu có
			if (includeProperties != null)
			{
				foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
				{
					query = query.Include(includeProperty);
				}
			}
			return query.FirstOrDefault();

		}

		public IEnumerable<T> GetAll(String? includeProperties = null)
		{
			IQueryable<T> query = dbSet;
			if (!string.IsNullOrEmpty(includeProperties))
			{   // mảng ký tự phân cách 
				foreach (var property in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
				{
					query = query.Include(property);

				}

			}
			return query.ToList();
		}
		public void Remove(T entity)
		{
			 dbSet.Remove(entity);
		}

		public void RemoveRange(IEnumerable<T> entities)
		{
			dbSet.RemoveRange(entities);
		}

		
	}
}
