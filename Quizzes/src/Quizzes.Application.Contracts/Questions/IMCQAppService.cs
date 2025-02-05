using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Quizzes.Questions;

public interface IMCQAppService :
    ICrudAppService<
        MCQDto,
        int,
        PagedAndSortedResultRequestDto,
        CreateUpdateMCQDto>
{

}
