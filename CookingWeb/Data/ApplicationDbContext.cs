using CookingWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace CookingWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { 

        }
        
        //creates table
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Breakfast", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Lunch", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Dinner", DisplayOrder = 3 },
                new Category { Id = 4, Name = "Desert", DisplayOrder = 4 },
                new Category { Id = 5, Name = "Snack", DisplayOrder = 5 }
                );
        }

    }
}
