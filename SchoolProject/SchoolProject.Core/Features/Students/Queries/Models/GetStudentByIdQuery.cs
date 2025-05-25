using MediatR;
using SchoolProject.Core.Features.Students.Queries.Responses;
using SchoolProject.Core.Helpers.BaseResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Students.Queries.Models
{
    public class GetStudentByIdQuery: IRequest<BaseResponse<GetStudentByIdResponse>>
    {
        public int id { get; }

        public GetStudentByIdQuery(int id)
        {
            this.id = id;
        }
    }
}
