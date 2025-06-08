using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<ToDoItem> ToDoItems { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ToDoItem>().HasData(
                new ToDoItem
                {
                    Id = 1,
                    Title = "Complete the project",
                    Description = "Adjust the final designs of the UI",
                    DueDate = DateTime.UtcNow.AddDays(7),
                    Priority = ToDoPriority.High,
                    IsCompleted = false
                },
                new ToDoItem
                {
                    Id = 2,
                    Title = "Refill food supplies",
                    Description = "Cooking oil, chicken, milk",
                    DueDate = DateTime.UtcNow.AddDays(3),
                    Priority = ToDoPriority.Medium,
                    IsCompleted = false
                }
            );
        }
    }
}
