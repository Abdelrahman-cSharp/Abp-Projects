using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;


namespace Quizzes.Questions;

public class QuizAppService :
    CrudAppService<
        Quiz,
        QuizDto,
        int,
        PagedAndSortedResultRequestDto,
        CreateUpdateQuizDto>,
    IQuizAppService
{
    private readonly IRepository<Quiz, int> _repository;

    public QuizAppService(
        IRepository<Quiz, int> repository)
        : base(repository)
    {
        _repository = repository;

    }

    /*public async Task TestQuizData()
    {
        // Using WithDetails to load MCQs and TFs
        List<Quiz> quizzes = await (await _repository.WithDetailsAsync(q => q.MCQs, q => q.TFs)).ToListAsync();

        // Output results to verify that MCQs and TFs are correctly loaded
        foreach (var quiz in quizzes)
        {
            Console.WriteLine($"{quiz.Title}: {quiz.MCQs.Count} MCQs, {quiz.TFs.Count} TFs");
        }
    }*/
    public override async Task<QuizDto> GetAsync(int id)
    {
        var quiz = await (await _repository.WithDetailsAsync(q => q.MCQs, q => q.TFs))
            .FirstOrDefaultAsync(q => q.Id == id);

        if (quiz == null)
        {
            throw new EntityNotFoundException(typeof(Quiz), id);
        }

        return ObjectMapper.Map<Quiz, QuizDto>(quiz);
    }

    public override async Task<PagedResultDto<QuizDto>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        List<Quiz> quizzes = await (await _repository.WithDetailsAsync(q => q.MCQs, q => q.TFs)).ToListAsync();


        var totalCount = quizzes.Count;
        var items = quizzes
            .Skip(input.SkipCount)
            .Take(input.MaxResultCount)
            .ToList();
        foreach (var quiz in quizzes)
        {
            Console.WriteLine($"{quiz.Title}: {quiz.MCQs.Count} MCQs, {quiz.TFs.Count} TFs");
        }

        return new PagedResultDto<QuizDto>(
            totalCount,
            ObjectMapper.Map<List<Quiz>, List<QuizDto>>(items)
        );
    }
    public override async Task<QuizDto> CreateAsync(CreateUpdateQuizDto input)
    {
        var quiz = new Quiz
        {
            Title = input.Title,
            TimeLimitMin = input.TimeLimitMin,
            AttemptsLimit = input.AttemptsLimit,
        };

        Quiz createdQuiz = await _repository.InsertAsync(quiz);
        return ObjectMapper.Map<Quiz, QuizDto>(createdQuiz);
    }
    public override async Task<QuizDto> UpdateAsync(int id, CreateUpdateQuizDto input)
    {
        Quiz quiz = await _repository.GetAsync(id);

        quiz.Title = input.Title;
        quiz.TimeLimitMin = input.TimeLimitMin;
        quiz.AttemptsLimit = input.AttemptsLimit;
        quiz.Attempts = input.Attempts;
        quiz.CorrectAnswersCount = input.CorrectAnswersCount;

        Quiz updatedQuiz = await _repository.UpdateAsync(quiz);
        return ObjectMapper.Map<Quiz, QuizDto>(updatedQuiz);
    }

    public async Task<QuizDto> AddTFAsync(int id, TFDto tfDto)
    {
        Quiz? quiz = await (await _repository.WithDetailsAsync(q => q.MCQs, q => q.TFs))
            .FirstOrDefaultAsync(q => q.Id == id);

        if (quiz == null)
        {
            throw new EntityNotFoundException(typeof(Quiz), id);
        }

        TF tf = ObjectMapper.Map<TFDto, TF>(tfDto);
        quiz.TFs.Add(tf);

        //await _repository.UpdateAsync(quiz);

        Quiz updatedQuiz = await _repository.UpdateAsync(quiz);
        return ObjectMapper.Map<Quiz, QuizDto>(updatedQuiz);
    }
    public async Task<QuizDto> AddMCQAsync(int id, MCQDto mcqDto)
    {
        Quiz? quiz = await (await _repository.WithDetailsAsync(q => q.MCQs, q => q.TFs))
            .FirstOrDefaultAsync(q => q.Id == id);

        if (quiz == null)
        {
            throw new EntityNotFoundException(typeof(Quiz), id);
        }

        MCQ mcq = ObjectMapper.Map<MCQDto, MCQ>(mcqDto);
        quiz.MCQs.Add(mcq);

        Quiz updatedQuiz = await _repository.UpdateAsync(quiz);
        return ObjectMapper.Map<Quiz, QuizDto>(updatedQuiz);
    }



}
