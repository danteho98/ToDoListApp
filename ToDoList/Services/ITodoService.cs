using ToDoList.Models;

namespace ToDoList.Services
{
    public interface IToDoService
    {
        Task<IEnumerable<ToDoItem>> GetAllToDosAsync();
        Task<ToDoItem?> GetTodoByIdAsync(int id);
        Task<IEnumerable<ToDoItem>> GetIncompleteToDosAsync();
        Task<IEnumerable<ToDoItem>> GetToDosByPriorityAsync(ToDoPriority priority);
        Task AddToDoAsync(ToDoItem ToDoItem);
        Task UpdateToDoAsync(ToDoItem toDoItem);
        Task DeleteToDoAsync(int id);
        Task<bool> ToDoExistAsync(int id);
    }
}
