using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Antiforgery;

namespace ToDoList.Models
{
    public class ToDoItem
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters")]
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public bool IsCompleted { get; set; }
        public Priority Priority { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }

    public enum Priority
    {
        Low,
        Medium,
        High,
        Urgent
    }

}
