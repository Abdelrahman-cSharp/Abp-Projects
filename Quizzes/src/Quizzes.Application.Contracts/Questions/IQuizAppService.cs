using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
namespace Quizzes.Questions;

public interface IQuizAppService :
    ICrudAppService<
        QuizDto,
        int,
        PagedAndSortedResultRequestDto,
        CreateUpdateQuizDto>
{
    // If something wrong remove "new"
    new Task<PagedResultDto<QuizDto>> GetListAsync(PagedAndSortedResultRequestDto input);
    Task<QuizDto> AddTFAsync(int id, TFDto tf);
    Task<QuizDto> AddMCQAsync(int id, MCQDto mcq);

}