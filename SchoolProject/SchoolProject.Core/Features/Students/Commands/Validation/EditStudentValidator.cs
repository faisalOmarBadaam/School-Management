using FluentValidation;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Service.Abstract;

namespace SchoolProject.Core.Features.Students.Commands.Validation
{
    public sealed class EditStudentValidator : AbstractValidator<EditStudentCommand>
    {
        private readonly IStudentService _service;

        public EditStudentValidator(IStudentService service)
        {
            _service = service;
            ApplyRoles();
            ApplyCustomeRoles();
        }



        private void ApplyRoles()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("id of the object did not send");

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
                .MustAsync(async (model, key, CancellationToken) => !await _service.CheckIfNameExistAsync(key, CancellationToken, model.Id))
                .WithMessage("Name is already there");

            RuleFor(x => x.Phone)
               .MustAsync(async (model, key, CancellationToken) => !await _service.CheckIfPhoneExistAsync(key, CancellationToken, model.Id))
               .WithMessage("Phone is already there");

        }
    }
}
