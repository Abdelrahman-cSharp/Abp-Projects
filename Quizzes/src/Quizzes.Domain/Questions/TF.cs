namespace Quizzes.Questions;

public class TF : Question
{
    public bool CorrectAnswer { get; set; }
    public bool? SelectedAnswer { get; set; } = null;
}
