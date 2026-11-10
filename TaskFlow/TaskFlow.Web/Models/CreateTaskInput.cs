using System.ComponentModel.DataAnnotations;

namespace TaskFlow.Web.Models;

public class CreateTaskInput
{
    [Required(ErrorMessage = "Task title is required.")]
    [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Description is required.")]
    [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
    public string Description { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please select a priority.")]
    public TaskPriority? Priority { get; set; }

    [DataType(DataType.Date)]
    public DateTime? DueDate { get; set; }
}
