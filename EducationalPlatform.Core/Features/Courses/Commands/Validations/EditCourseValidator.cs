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

            RuleFor(x => x.Id).NotEmpty().WithMessage("Id must has value");

            RuleFor(x => x.Name).NotEmpty().WithMessage("Name must has value");


        }
    }
}
