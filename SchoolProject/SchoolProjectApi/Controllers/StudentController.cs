using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Core.Helpers.Routes;

namespace SchoolProjectApi.Controllers
{
    [ApiController]
    public class StudentController : ControllerBase
    {

        public StudentController(IMediator mediator)
        {
            _Mediator = mediator;
        }

        public IMediator _Mediator { get; }

        [HttpGet(Router.StudentRouting.List)]
        public async Task<IActionResult> GetAllStudents([FromQuery] string? searchTerm, string? sortCloumn, string? sortOrder, int page, int pageSize)
        {
            var response = await _Mediator.Send(new GetStudentListQuery(searchTerm, sortCloumn, sortOrder, page, pageSize));
            return response.Succeeded ? Ok(response) : BadRequest(response);
        }
        [HttpGet(Router.StudentRouting.ByID)]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var response = await _Mediator.Send(new GetStudentByIdQuery(id));
            return Ok(response);
        }
        [HttpPost(Router.StudentRouting.Add)]
        public async Task<IActionResult> AddStudent(AddStudentCommand newStudent)
        {

            var response = await _Mediator.Send(newStudent);
            return response.Succeeded ? Created("", response) : BadRequest(response);
        }

        [HttpPut(Router.StudentRouting.Edit)]
        public async Task<IActionResult> EditStudent(EditStudentCommand Student)
        {

            var response = await _Mediator.Send(Student);
            return response.Succeeded ? Ok(response) : NotFound(response);
        }

        [HttpDelete(Router.StudentRouting.DeleteById)]
        public async Task<IActionResult> DeleteStudent(int id)
        {

            var response = await _Mediator.Send(new DeleteStudentCommand(id));
            return response.Succeeded ? Ok(response) : NotFound(response);
        }
    }
}
