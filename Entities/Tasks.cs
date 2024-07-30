using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDo.Entities
{
    [Table("Tasks", Schema = "ToDo")]
    public class Tasks
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TaskId { get; set; }
        [Required]
        [ForeignKey("TaskPriorityCategory")]
        public int TaskPriorityCategoryId { get; set; }
        [Required]
        public string TaskName { get; set; }
        [Required]
        public DateTime DateFrom { get; set; }
        [Required]
        public DateTime DateTo { get; set; }
        [Required]
        public string TaskStatus { get; set; }
        [Required]
        public string TaskDescription { get; set; }
        [Required]
        [ForeignKey("Username")]
        public string Username { get; set; }
    }
}
