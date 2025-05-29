using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TasksApi.Entities;

[Table("MojTasks")]
public class MojTask
{
    [Key]
    public int TaskId { get; set; }
    [MaxLength(2000)]
    public string? TaskDescription { get; set; } = "";
    [Required]
    public required string TaskStatus { get; set; }
    [Required]
    public DateOnly TaskDueDate { get; set; }

}
