using System.ComponentModel.DataAnnotations;

namespace Mission08_Team0109.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; } = string.Empty;

        public List<TaskItem> TaskItems { get; set; } = new List<TaskItem>();
    }
}
