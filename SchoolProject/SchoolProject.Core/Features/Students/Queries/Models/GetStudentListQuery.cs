using MediatR;
using SchoolProject.Core.Features.Students.Queries.Responses;
using SchoolProject.Core.Helpers;
using SchoolProject.Core.Helpers.BaseResponse;

namespace SchoolProject.Core.Features.Students.Queries.Models
{
    public record GetStudentListQuery(string searchItem, string sortColumn, string sortOrder, int page, int pageSize) : IRequest<BaseResponse<PageList<GetStudentListResponse>>>
    {

    }
}
