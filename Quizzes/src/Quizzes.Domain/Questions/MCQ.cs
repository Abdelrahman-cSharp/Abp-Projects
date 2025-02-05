namespace Quizzes.Questions;

public class MCQ : Question
{
    public string? Choice1 { get; set; }
    public string? Choice2 { get; set; }
    public string? Choice3 { get; set; }
    public string? Choice4 { get; set; }
    public string? CorrectAnswer { get; set; }
    public string? SelectedAnswer { get; set; } = null;

}
