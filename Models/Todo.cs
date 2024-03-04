using System.ComponentModel.DataAnnotations;
using asp_todo.Validators;

namespace asp_todo.Models;

public class Todo{
  public int Id { get; set; }
  
  [Required(ErrorMessage = "The field {0} is required!")]
  [StringLength(100, MinimumLength = 3, ErrorMessage = "The field {0} must be between {2} and {1} characters!")]
  public string Title { get; set; } = string.Empty;
  public DateTime CreatedAt { get; set; } = DateTime.Now;

  [Required(ErrorMessage = "The field {0} is required!")]
  [FutureOrPresent]
  public DateOnly DeadLine { get; set; }
  public DateOnly? FinishedAt { get; set; }

  public void Finish(){
    FinishedAt = DateOnly.FromDateTime(DateTime.Now);
  }
}