using Microsoft.EntityFrameworkCore;
using ToDoList.Data;
using ToDoList.Models;

namespace ToDoList.Services
{
    public class IToDoService: ITodoService
    {
        private readonly ApplicationDbContext _context;
        public IToDoService(ApplicationDbContext context) 
        {
            _context = context;
        }
        public async Task<IEnumerable<ToDoItem>> GetAllToDosAsync()
        {
            return await _context.ToDoItems
                .OrderByDescending(t => t.Priority)
                .ThenBy(t=> t.DueDate)
                .ToListAsync();
        }
        public async Task<ToDoItem?> GetTodoByIdAsync(int id)
        {
            return await _context.ToDoItems.FindAsync(id);
        }

        public async Task<IEnumerable<ToDoItem>> GetIncompleteToDosAsync()
        {
            return await _context.ToDoItems
                .Where(t => !t.IsCompleted)
                .OrderByDescending(t => t.Priority)
                .ThenBy(t => t.DueDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<ToDoItem>> GetToDosByPriorityAsync(ToDoPriority priority)
        {
            return await _context.ToDoItems
                .Where(t => t.Priority == priority)
                .OrderBy(t => t.DueDate)
                .ToListAsync();
        }

        public async Task AddToDoAsync(ToDoItem ToDoItem)
        {
            _context.ToDoItems.Add(ToDoItem);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateToDoAsync(ToDoItem ToDoItem)
        {
            _context.Entry(ToDoItem).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteToDoAsync(int id)
        {
            var toDoItem = await _context.ToDoItems.FindAsync(id);
            if (toDoItem != null)
            {
                _context.ToDoItems.Remove(toDoItem);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ToDoExistAsync(int id)
        {
            return await _context.ToDoItems.AnyAsync(t => t.Id == id);
        }

    }
}
