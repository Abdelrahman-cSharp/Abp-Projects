using Volo.Abp.Application.Dtos;

namespace Quizzes.Questions;

public class TFDto : AuditedEntityDto<int>
{
    public required string Title { get; set; }
    public bool Answered { get; set; }
    public required bool CorrectAnswer { get; set; }
    public bool? SelectedAnswer { get; set; } = null;
    public int QuizId { get; set; }
    public QuizDto? Quiz { get; set; }
}
