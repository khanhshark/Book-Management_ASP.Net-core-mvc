using Microsoft.EntityFrameworkCore;
using BookASP.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace BookASP.DataAccess.data
{
    public class ApplicationDbContext: IdentityDbContext<IdentityUser>
	{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ApplicationUsers> ApplicationUsers {  get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			// Gọi base để áp dụng các cấu hình của IdentityDbContext
			base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
	                new Category { Id = 1, Name = "main", DisplayOrder = 1 },
	                new Category { Id = 2, Name = "name", DisplayOrder = 2 }
                );
            modelBuilder.Entity<Product>().HasData(
               new Product
               {
                   Id = 1,
                   Title = "The Great Gatsby",
                   Description = "A novel by F. Scott Fitzgerald.",
                   ISBN = "978-0743273565",
                   Author = "F. Scott Fitzgerald",
                   ListPrice = 20,
                   Price = 18,
                   Price50 = 15,
                   Price100 = 10,
                   CategoryId=1,
                   ImageUrl=""
               },
                new Product
                {
                    Id = 2,
                    Title = "To Kill a Mockingbird",
                    Description = "A novel by Harper Lee.",
                    ISBN = "978-0061120084",
                    Author = "Harper Lee",
                    ListPrice = 25,
                    Price = 22,
                    Price50 = 18,
                    Price100 = 12,
					CategoryId = 1,
					ImageUrl = ""
				},
                new Product
                {
                    Id = 3,
                    Title = "1984",
                    Description = "A novel by George Orwell.",
                    ISBN = "978-0451524935",
                    Author = "George Orwell",
                    ListPrice = 15,
                    Price = 13,
                    Price50 = 11,
                    Price100 = 8,
					CategoryId = 1,
					ImageUrl = ""
				}
                );

		}
    }
   

}
