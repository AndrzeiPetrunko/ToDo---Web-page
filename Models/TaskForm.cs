namespace ToDo.Models
{
    public class TaskForm
    {
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public int TaskPriorityCategoryId { get; set; }
        public string TaskStatus { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string Username { get; set; }
    }
}

