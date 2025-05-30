namespace ToDoList.Models
{
    public class ToDoItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public bool IsCompleted { get; set; }
        public ToDoPriority Priority { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }

    public enum ToDoPriority
    {
        Low,
        Medium,
        High,
        Urgent
    }

}
