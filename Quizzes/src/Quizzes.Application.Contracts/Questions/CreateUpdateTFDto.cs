using System.ComponentModel.DataAnnotations;

namespace Quizzes.Questions;

public class CreateUpdateTFDto
{
    [Required(ErrorMessage = "Title is required.")]
    [StringLength(512, ErrorMessage = "Title cannot exceed 512 characters.")]
    public string Title { get; set; } = string.Empty;

    [Required]
    public bool CorrectAnswer { get; set; }

    public bool? SelectedAnswer { get; set; } = null;
}
