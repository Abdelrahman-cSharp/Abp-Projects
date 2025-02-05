using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Quizzes.Questions;

public interface ITFAppService :
    ICrudAppService<
        TFDto,
        int,
        PagedAndSortedResultRequestDto,
        CreateUpdateTFDto>
{

}
