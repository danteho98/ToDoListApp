using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList.ToDoDbContext
{
    public class ToDoDbContext : DbContext
    {
        public ToDoDbContext(DbContextOptions<ToDoDbContext> options) : base(options) { }

        public DbSet<ToDoItem> ToDoItems { get; set; }
    }
}
