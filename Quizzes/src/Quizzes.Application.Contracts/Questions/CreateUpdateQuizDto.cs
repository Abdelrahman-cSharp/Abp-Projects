using System;
using System.ComponentModel.DataAnnotations;

public class CreateUpdateQuizDto
{
    [Required(ErrorMessage = "Title is required.")]
    [StringLength(50, ErrorMessage = "Title cannot exceed 50 characters.")]
    public string Title { get; set; } = string.Empty;
    [Required]
    [Range(1, 120, ErrorMessage = "Time limit must be between 1 and 120 min.")]
    public int TimeLimitMin { get; set; } = 5;
    [Required]
    [Range(1, 9, ErrorMessage = "Attempts limit must be between 1 and 9.")]
    public int AttemptsLimit { get; set; } = 1;
    public int Attempts { get; set; }
    public int CorrectAnswersCount { get; set; }
}
