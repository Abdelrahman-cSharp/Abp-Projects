using System.Text.Json.Serialization;
using Volo.Abp.Domain.Entities.Auditing;

namespace Quizzes.Questions;

public abstract class Question : AuditedAggregateRoot<int>
{
    public string? Title { get; set; }
    public int QuizId { get; set; }
    [JsonIgnore]
    public Quiz? Quiz { get; set; }
}
