using FluentValidation;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Service.Abstract;

namespace SchoolProject.Core.Features.Students.Commands.Validation
{
    public sealed class AddStudentValidator : AbstractValidator<AddStudentCommand>
    {
        private readonly IStudentService _studentService;
        public AddStudentValidator(IStudentService studentService) : base()
        {
            ApplyRoles();
            ApplyCustomeRoles();
            _studentService = studentService;
        }
        private void ApplyRoles()
        {


            RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .Length(2, 50).WithMessage("Name must be between 2 and 50 characters.");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Phone number is required")
                .Matches(@"^(77|78|73)\d{7}$")
                .WithMessage("Phone number must start with 77, 78, or 73 and contain exactly 9 digits.");

        }

        private void ApplyCustomeRoles()
        {
            RuleFor(x => x.Name)
                .MustAsync(async (key, CancellationToken) => !await (_studentService.CheckIfNameExistAsync(key, CancellationToken)))
                .WithMessage("Name is already there");

            RuleFor(x => x.Phone)
               .MustAsync(async (key, CancellationToken) => !await _studentService.CheckIfPhoneExistAsync(key, CancellationToken))
               .WithMessage("Phone is already there");

        }
    }
}
