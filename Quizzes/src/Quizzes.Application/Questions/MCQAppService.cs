using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Quizzes.Questions;

public class MCQAppService : CrudAppService<
        MCQ,
        MCQDto,
        int,
        PagedAndSortedResultRequestDto,
        CreateUpdateMCQDto>,
        IMCQAppService
{
    public MCQAppService(IRepository<MCQ, int> repository)
        : base(repository)
    {
    }


}
