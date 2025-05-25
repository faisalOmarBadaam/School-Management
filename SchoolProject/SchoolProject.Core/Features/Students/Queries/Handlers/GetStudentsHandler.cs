using MediatR;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Core.Features.Students.Queries.Responses;
using SchoolProject.Core.Helpers;
using SchoolProject.Core.Helpers.BaseResponse;
using SchoolProject.Service.Abstract;

namespace SchoolProject.Core.Features.Students.Queries.Handlers
{
    public class GetStudentsHandler : IRequestHandler<GetStudentListQuery, BaseResponse<PageList<GetStudentListResponse>>>
    {
        private readonly IStudentService _Service;

        public GetStudentsHandler(IStudentService service)
        {
            this._Service = service;
        }
        public async Task<BaseResponse<PageList<GetStudentListResponse>>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            var students = _Service.GetStudentsAsync(request.searchItem, request.sortColumn, request.sortOrder);

            var studentsResponse = students
            .Select(x => new GetStudentListResponse
            {
                Id = x.Id,
                Address = x.Address,
                DepartmentName = x.Department.Name,
                Name = x.Name,
                Phone = x.Phone,
            });
            var pagedStudentsResponse = await PageList<GetStudentListResponse>.CreateAsync(studentsResponse, request.page, request.pageSize);
            return new BaseResponse<PageList<GetStudentListResponse>>(true, pagedStudentsResponse, null, null);

        }
    }
}
