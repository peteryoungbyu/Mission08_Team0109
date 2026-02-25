using Microsoft.EntityFrameworkCore;

namespace Mission08_Team0109.Models
{
    public class TaskDbContext : DbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options)
        {
        }

        public DbSet<TaskItem> Tasks { get; set; }
        public DbSet<Category> Categories { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
    
                // Seed initial categories
                modelBuilder.Entity<Category>().HasData(
                    new Category { CategoryId = 1, CategoryName = "Home" },
                    new Category { CategoryId = 2, CategoryName = "School" },
                    new Category { CategoryId = 3, CategoryName = "Work" },
                    new Category { CategoryId = 4, CategoryName = "Church" }
                );
        }
    }
}
