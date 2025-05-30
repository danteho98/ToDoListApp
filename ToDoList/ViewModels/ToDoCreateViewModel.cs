using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ToDoList.Models;

namespace ToDoList.ViewModels
{
    public class ToDoCreateViewModel
    {
        [Required]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        [DisplayName("Due Date")]
        [DataType(DataType.Date)]
        public DateTime? DueDate { get; set; }

        public ToDoPriority Priority { get; set; } = ToDoPriority.Medium;

    }
}
