using MediatR;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Helpers.BaseResponse;
using SchoolProject.Data.Exceptions;
using SchoolProject.Service.Abstract;

namespace SchoolProject.Core.Features.Students.Commands.Handlers
{
    internal sealed class EditStudentHandler : IRequestHandler<EditStudentCommand, BaseResponse<string>>
    {
        private readonly IStudentService _service;

        public EditStudentHandler(IStudentService service)
        {
            this._service = service;
        }
        public async Task<BaseResponse<string>> Handle(EditStudentCommand request, CancellationToken cancellationToken)
        {
            var exitedStudent = await _service.GetStudentByIDAsync(request.Id);
            if (exitedStudent == null)
                throw new NotFoundException($"not found {request.Id}");
            exitedStudent.Name = request.Name;
            exitedStudent.Address = request.Address;
            exitedStudent.Phone = request.Phone;
            exitedStudent.Department.Id = (int)request.DepartmentID!;
            await _service.UpdateAsync(exitedStudent);
            return new BaseResponse<string>(true, null, "Edit successfly", null);
        }
    }
}
