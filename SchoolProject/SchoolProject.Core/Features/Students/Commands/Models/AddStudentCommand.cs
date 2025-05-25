using MediatR;
using SchoolProject.Core.Helpers.BaseResponse;

namespace SchoolProject.Core.Features.Students.Commands.Models
{
    public record AddStudentCommand : IRequest<BaseResponse<string>>
    {

        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public int? DepartmentID { get; set; }

    }

}
