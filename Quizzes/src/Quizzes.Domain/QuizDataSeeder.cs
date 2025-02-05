using Quizzes.Questions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

public class QuizDataSeeder : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<Quiz, int> _quizRepository;

    public QuizDataSeeder(IRepository<Quiz, int> quizRepository)
    {
        _quizRepository = quizRepository;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        if (await _quizRepository.GetCountAsync() > 0)
        {
            return;
        }

        var quizzes = new List<Quiz>
        {
            new Quiz
            {
                Title = "General Knowledge Quiz",
                TimeLimitMin = 5,
                AttemptsLimit = 1,
                MCQs = new List<MCQ>
                {
                    new MCQ
                    {
                        Title = "What is the capital of Italy?",
                        Choice1 = "Rome",
                        Choice2 = "Paris",
                        Choice3 = "Berlin",
                        Choice4 = "Madrid",
                        CorrectAnswer = "Rome"
                    },
                    new MCQ
                    {
                        Title = "Who wrote 'Hamlet'?",
                        Choice1 = "Shakespeare",
                        Choice2 = "Hemingway",
                        Choice3 = "Dickens",
                        Choice4 = "Austen",
                        CorrectAnswer = "Shakespeare"
                    }
                },
                TFs = new List<TF>
                {
                    new TF { Title = "The sun rises in the west.", CorrectAnswer = false },
                    new TF { Title = "Water boils at 100°C.", CorrectAnswer = true }
                }
            },
            new Quiz
            {
                Title = "Math Quiz",
                TimeLimitMin = 7,
                AttemptsLimit = 9,
                MCQs = new List<MCQ>
                {
                    new MCQ
                    {
                        Title = "What is 10 + 15?",
                        Choice1 = "20",
                        Choice2 = "25",
                        Choice3 = "30",
                        Choice4 = "35",
                        CorrectAnswer = "25"
                    },
                    new MCQ
                    {
                        Title = "What is 12 * 3?",
                        Choice1 = "32",
                        Choice2 = "34",
                        Choice3 = "36",
                        Choice4 = "38",
                        CorrectAnswer = "36"
                    }
                },
                TFs = new List<TF>
                {
                    new TF { Title = "A square has four equal sides.", CorrectAnswer = true },
                    new TF { Title = "The number 5 is even.", CorrectAnswer = false }
                }
            },
            new Quiz
            {
                Title = "Science Quiz",
                TimeLimitMin = 3,
                AttemptsLimit = 4,
                MCQs = new List<MCQ>
                {
                    new MCQ
                    {
                        Title = "What is the chemical symbol for water?",
                        Choice1 = "H2O",
                        Choice2 = "O2",
                        Choice3 = "CO2",
                        Choice4 = "N2",
                        CorrectAnswer = "H2O"
                    },
                    new MCQ
                    {
                        Title = "Which planet is known as the Red Planet?",
                        Choice1 = "Venus",
                        Choice2 = "Mars",
                        Choice3 = "Jupiter",
                        Choice4 = "Saturn",
                        CorrectAnswer = "Mars"
                    }
                },
                TFs = new List<TF>
                {
                    new TF { Title = "Sound travels faster in air than in water.", CorrectAnswer = false },
                    new TF { Title = "The Earth orbits the Sun.", CorrectAnswer = true }
                }
            },
            new Quiz
            {
                Title = "History Quiz",
                TimeLimitMin = 15,
                AttemptsLimit = 5,
                MCQs = new List<MCQ>
                {
                    new MCQ
                    {
                        Title = "Who discovered America?",
                        Choice1 = "Columbus",
                        Choice2 = "Magellan",
                        Choice3 = "Cook",
                        Choice4 = "Vespucci",
                        CorrectAnswer = "Columbus"
                    },
                    new MCQ
                    {
                        Title = "When did World War II end?",
                        Choice1 = "1943",
                        Choice2 = "1945",
                        Choice3 = "1947",
                        Choice4 = "1950",
                        CorrectAnswer = "1945"
                    }
                },
                TFs = new List<TF>
                {
                    new TF { Title = "The Great Wall of China was built in a single year.", CorrectAnswer = false },
                    new TF { Title = "Napoleon was a French leader.", CorrectAnswer = true }
                }
            },
            new Quiz
            {
                Title = "Technology Quiz",
                TimeLimitMin = 2,
                AttemptsLimit = 2,
                MCQs = new List<MCQ>
                {
                    new MCQ
                    {
                        Title = "What does 'CPU' stand for?",
                        Choice1 = "Central Processing Unit",
                        Choice2 = "Central Power Unit",
                        Choice3 = "Computer Personal Unit",
                        Choice4 = "Central Performance Unit",
                        CorrectAnswer = "Central Processing Unit"
                    },
                    new MCQ
                    {
                        Title = "Which company developed Windows OS?",
                        Choice1 = "Apple",
                        Choice2 = "IBM",
                        Choice3 = "Microsoft",
                        Choice4 = "Google",
                        CorrectAnswer = "Microsoft"
                    }
                },
                TFs = new List<TF>
                {
                    new TF { Title = "The first iPhone was released in 2005.", CorrectAnswer = false },
                    new TF { Title = "HTML is a programming language.", CorrectAnswer = false }
                }
            }
        };

        foreach (var quiz in quizzes)
        {
            await _quizRepository.InsertAsync(quiz, autoSave: true);
        }
    }
}
