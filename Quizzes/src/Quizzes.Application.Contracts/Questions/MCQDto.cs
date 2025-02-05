using Volo.Abp.Application.Dtos;

namespace Quizzes.Questions;

public class MCQDto : AuditedEntityDto<int>
{
    public required string Title { get; set; }
    public required string Choice1 { get; set; }
    public required string Choice2 { get; set; }
    public required string Choice3 { get; set; }
    public required string Choice4 { get; set; }
    public required string CorrectAnswer { get; set; }
    public string? SelectedAnswer { get; set; } = null;
    public int QuizId { get; set; }
    public QuizDto? Quiz { get; set; }
}
