using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Quizzes.Questions;

public class TFAppService : CrudAppService<
    TF,
    TFDto,
    int,
    PagedAndSortedResultRequestDto,
    CreateUpdateTFDto>,
    ITFAppService
{
    public TFAppService(IRepository<TF, int> repository)
        : base(repository)
    {
    }

}
