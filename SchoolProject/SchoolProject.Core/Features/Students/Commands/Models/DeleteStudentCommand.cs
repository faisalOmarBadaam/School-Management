using MediatR;
using SchoolProject.Core.Helpers.BaseResponse;

namespace SchoolProject.Core.Features.Students.Commands.Models
{
    public record DeleteStudentCommand(int id) : IRequest<BaseResponse<string>>
    {

    }
}
