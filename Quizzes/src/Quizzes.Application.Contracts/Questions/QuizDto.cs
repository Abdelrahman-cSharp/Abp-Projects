using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace Quizzes.Questions;

public class QuizDto : AuditedEntityDto<int>
{
    public required string Title { get; set; }
    public List<MCQDto> MCQs { get; set; } = new List<MCQDto>();
    public List<TFDto> TFs { get; set; } = new List<TFDto>();
    public int TimeLimitMin { get; set; }
    public int AttemptsLimit { get; set; }
    public int Attempts { get; set; }
    public int CorrectAnswersCount { get; set; }
}

