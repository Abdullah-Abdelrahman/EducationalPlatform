using EducationalPlatform.Core.Features.Courses.Commands.Models;
using FluentValidation;

namespace EducationalPlatform.Core.Features.Courses.Commands.Validations
{
    public class EditCourseValidator : AbstractValidator<EditCourseCommand>
    {

        public EditCourseValidator()
        {
            ValidationRules();
        }

        public void ValidationRules()
        {

            RuleFor(x => x.Id).NotNull().WithMessage("Id must not be null").NotEmpty().WithMessage("Id must has value");


            RuleFor(x => x.Name).NotNull().WithMessage("Name must not be null").NotEmpty().WithMessage("Name must has value");

        }
    }
}
