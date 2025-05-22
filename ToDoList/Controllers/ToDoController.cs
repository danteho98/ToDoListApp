using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using ToDoList.Services;

namespace ToDoList.Controllers
{
    public class ToDoController : Controller
    {
        private readonly IToDoService _toDoService;

        public ToDoController(IToDoService toDoService)
        {
            _toDoService = toDoService;
        }

        public async Task<IActionResult> Index()
        {
            var todo = await _toDoService.GetAllToDosAsync();
            return View(todo);
        }

        public async Task <IActionResult> Details (int id)
        {
            var todoItem = await _toDoService.GetTodoByIdAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }

            return View(todoItem);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind(
            "Title, Description, DueDate, Priority")] ToDoItem toDoItem)
        {
            if (ModelState.IsValid)
            {
                toDoItem.CreatedAt = DateTime.Now;
                await _toDoService.AddToDoAsync(toDoItem);
                return RedirectToAction("Index");
            }
            return View(toDoItem);
        }

        public async Task<IActionResult>Edit(int id)
        {
            var toDoItem = await _toDoService.GetTodoByIdAsync(id);
            if (toDoItem == null)
            {
                return NotFound();
            }
            return View(toDoItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind(
            "Id, Title, Description, DueDate, IsComplete, Priority, CreatedAt")] ToDoItem toDoItem)
        {
            if (id != toDoItem.Id) 
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _toDoService.UpdateToDoAsync(toDoItem);
                return RedirectToAction(nameof(Index));
            }
            return View(toDoItem);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var toDoItem = await _toDoService.GetTodoByIdAsync(id);
            if (toDoItem != null)
            {
                return NotFound();
            }

            return View(toDoItem);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _toDoService.DeleteToDoAsync(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> ToggleComplete(int id)
        {
            var toDoItem = await _toDoService.GetTodoByIdAsync(id);
            if (toDoItem == null)
            {  
                return NotFound(); 
            }

            toDoItem.IsCompleted = !toDoItem.IsCompleted;
            await _toDoService.UpdateToDoAsync(toDoItem);
            return RedirectToAction(nameof(Index));
        }
    }
}
