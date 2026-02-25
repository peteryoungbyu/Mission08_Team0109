using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission08_Team0109.Models
{
    public class TaskItem
    {
        // Primary key
        // Task (required)
        // Due Date
        // Quadrant (required)
        // Categroy (dropdown containing options: Home, School, Work, Church)
        //Completed (true/false)

        [Key]
        public int TaskId { get; set; }
        [Required(ErrorMessage ="Task is Required")]
        public string TaskName { get; set; } = string.Empty;
        [DataType(DataType.Date)]
        public DateTime? DueDate { get; set; }
        [Required(ErrorMessage = "Quadrant is Required")]
        [Range(1, 4, ErrorMessage = "Quadrant must be between 1 and 4")]
        public int Quadrant { get; set; }
        [Required(ErrorMessage = "Category is Required")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }
        public bool Completed { get; set; } = false;
    }
}
