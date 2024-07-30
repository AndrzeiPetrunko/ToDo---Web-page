using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ToDo.Entities;

namespace ToDo.Models
{
    public class TasksModel
    {
        public int TaskId { get; set; }
        public int TaskPriorityCategoryId { get; set; }
        public string CategoryName { get; set; }
        public string TaskName { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string TaskStatus { get; set; }
        public string TaskDescription { get; set; }
        public User User { get; set; }
    }
}
