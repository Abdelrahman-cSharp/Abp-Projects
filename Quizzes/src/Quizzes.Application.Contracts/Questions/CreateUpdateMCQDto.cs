using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
namespace Quizzes.Questions;

public class CreateUpdateMCQDto
{
    [Required(ErrorMessage = "Title is required.")]
    [StringLength(512, ErrorMessage = "Title cannot exceed 512 characters.")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Correct answer is required.")]
    [StringLength(512, ErrorMessage = "Correct answer cannot exceed 512 characters.")]
    [CorrectAnswerMatchChoices(ErrorMessage = "Correct answer must match one of the choices.")]
    public string CorrectAnswer { get; set; } = string.Empty;

    [Required(ErrorMessage = "Choice a. is required.")]
    [StringLength(512, ErrorMessage = "Choice a. cannot exceed 512 characters.")]
    public string Choice1 { get; set; } = string.Empty;

    [Required(ErrorMessage = "Choice b. is required.")]
    [StringLength(512, ErrorMessage = "Choice b. cannot exceed 512 characters.")]
    public string Choice2 { get; set; } = string.Empty;

    [Required(ErrorMessage = "Choice c. is required.")]
    [StringLength(512, ErrorMessage = "Choice c. cannot exceed 512 characters.")]
    public string Choice3 { get; set; } = string.Empty;

    [Required(ErrorMessage = "Choice d. is required.")]
    [StringLength(512, ErrorMessage = "Choice d. cannot exceed 512 characters.")]
    public string Choice4 { get; set; } = string.Empty;
    public string? SelectedAnswer { get; set; } = null;
}


public class CorrectAnswerMatchChoicesAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var instance = (CreateUpdateMCQDto)validationContext.ObjectInstance;

        if (value != null &&
            !new[] { instance.Choice1, instance.Choice2, instance.Choice3, instance.Choice4 }
            .Contains(value.ToString()))
        {
            return new ValidationResult("Correct answer must match one of the choices.");
        }

        return ValidationResult.Success;
    }
}




