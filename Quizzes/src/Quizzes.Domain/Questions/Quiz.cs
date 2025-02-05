using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;

namespace Quizzes.Questions;

public class Quiz : AuditedAggregateRoot<int>
{
    public string? Title { get; set; }
    public ICollection<MCQ> MCQs { get; set; } = new List<MCQ>();
    public ICollection<TF> TFs { get; set; } = new List<TF>();
    public int TimeLimitMin { get; set; }
    public int AttemptsLimit { get; set; } = 1;
    public int Attempts { get; set; }
    public int CorrectAnswersCount { get; set; }
}
