using MediatR;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Helpers.BaseResponse;
using SchoolProject.Data.Exceptions;
using SchoolProject.Service.Abstract;

namespace SchoolProject.Core.Features.Students.Commands.Handlers
{
    public sealed class DeleteStudentHandler : IRequestHandler<DeleteStudentCommand, BaseResponse<string>>
    {
        private readonly IStudentService _studentService;

        public DeleteStudentHandler(IStudentService studentService)
        {
            _studentService = studentService;
        }
        public async Task<BaseResponse<string>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var ExitedStudent = await _studentService.GetStudentByIDAsync(request.id);
            if (ExitedStudent == null)
                throw new NotFoundException($"The {request.id} is not found");
            await _studentService.DeleteAsync(ExitedStudent);
            return new BaseResponse<string>(true, null, $"delete id {ExitedStudent.Id} Successfly", null);
        }
    }
}
