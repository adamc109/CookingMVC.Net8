using Cooking.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Cooking.DataAccess.Data1

{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        //creates table
        public DbSet<Category> Categories { get; set; }
        public DbSet<Recipie> Recipies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Breakfast", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Lunch", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Dinner", DisplayOrder = 3 },
                new Category { Id = 4, Name = "Desert", DisplayOrder = 4 },
                new Category { Id = 5, Name = "Snack", DisplayOrder = 5 }
                );

            modelBuilder.Entity<Recipie>().HasData(
                new Recipie
                {
                    Id = 1,
                    Title = "Steak & Chips",
                    Ingredients = "Steak, chips",
                    ListPrice = 10,
                    Price = 10,
                    Price50 = 8,
                    Price100 = 5,
                    CategoryId = 2,
                    ImageURL =""

                },
                new Recipie
                {
                    Id = 2,
                    Title = "McMuffin",
                    Ingredients = "sausage burger, bun",
                    ListPrice = 8,
                    Price = 8,
                    Price50 = 7,
                    Price100 = 3,
                    CategoryId = 1,
                    ImageURL = ""

                }

                );
        }

    }
}
