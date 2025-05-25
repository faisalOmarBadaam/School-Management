using MediatR;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Core.Features.Students.Queries.Responses;
using SchoolProject.Core.Helpers.BaseResponse;
using SchoolProject.Data.Exceptions;
using SchoolProject.Service.Abstract;

namespace SchoolProject.Core.Features.Students.Queries.Handlers
{
    public class GetStudentByIdHandler : IRequestHandler<GetStudentByIdQuery, BaseResponse<GetStudentByIdResponse>>

    {
        public GetStudentByIdHandler(IStudentService service)
        {
            _Service = service;
        }

        private IStudentService _Service { get; }


        public async Task<BaseResponse<GetStudentByIdResponse>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _Service.GetStudentByIDAsync(request.id);
            if (student == null)
            {
                throw new NotFoundException($"there is no student with {request.id}");
            }

            var studentResponse = new GetStudentByIdResponse
            {
                Id = student.Id,
                Address = student.Address,
                DepartmentName = student.Department.Name,
                Name = student.Name,
                Phone = student.Phone

            };
            return new BaseResponse<GetStudentByIdResponse>(true, studentResponse, null, null);
        }
    }
}
