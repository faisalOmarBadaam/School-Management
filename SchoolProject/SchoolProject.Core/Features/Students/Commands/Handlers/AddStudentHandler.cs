using MediatR;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Helpers.BaseResponse;
using SchoolProject.Data.Models;
using SchoolProject.Service.Abstract;

namespace SchoolProject.Core.Features.Students.Commands.Handlers
{
    public sealed class AddStudentHandler : IRequestHandler<AddStudentCommand, BaseResponse<string>>
    {
        private readonly IStudentService _service;

        public AddStudentHandler(IStudentService service)
        {
            this._service = service;
        }
        public async Task<BaseResponse<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {

            var NewStudent = new Student
            {
                Name = request.Name,
                Address = request.Address,
                DepartmentID = request.DepartmentID,
                Phone = request.Phone,
            };
            await _service.AddAsync(NewStudent, cancellationToken);
            return new BaseResponse<string>(true, null, "Added successfly", null);
        }
    }
}
