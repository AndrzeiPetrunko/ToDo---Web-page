using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDo.Entities
{
    [Table("TaskPriorityCategory", Schema = "ToDo")]
    public class TaskPriorityCategory
    {
        [Key]
        public int TaskPriorityCategoryId { get; set; }
        [Required]
        public string CategoryName {  get; set; }

    }
}
