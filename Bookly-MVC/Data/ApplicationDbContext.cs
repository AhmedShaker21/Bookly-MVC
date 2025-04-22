using Bookly_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookly_MVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options ): base (options)
        { 
            
        }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                 new Category
                 {
                     Id = 1,
                     Name = "Book name 1",
                     DisplayOrder = 1
                 },
                 new Category
                 {
                     Id = 2,
                     Name = "Book name 2",
                     DisplayOrder = 2
                 },
                 new Category
                 {
                     Id = 3,
                     Name = "Book name 3",
                     DisplayOrder = 3
                 }

                );
        }
    }
}
