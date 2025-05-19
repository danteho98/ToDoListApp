namespace ToDoList.Services
{
    public interface ITodoService
    {
        Task<IEnumerable<ToDoItem>> GetAllToDoAsync();
        Task<ToDoItem?> GetTodayByIdAssync(int id);
        Task<IEnumerable<TodoItem>> GetincompleteToDoAsync();
        Task<IEnumerable<ToDoItem>> GetToDosByPriorityAsync(ToDoPriority priority);
        Task AddToDoAsync(ToDoItem ToDoItem);
        Task UpdateToDoAsync(ToDoItem toDoItem);
        Task DeleteToDoAsync(int id);
        Task<bool> ToDoExistAsync(int id);
    }
}
