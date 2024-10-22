using EducationalPlatform.Core.Features.Enrollment.Commands.Models;
using FluentValidation;

namespace EducationalPlatform.Core.Features.Enrollment.Commands.Validations
{
    public class AddEnrollmentValidator : AbstractValidator<AddEnrollmentCommand>
    {

        #region
        public AddEnrollmentValidator()
        {
            ValidationRules();
            CustomValidationRules();
        }
        #endregion
        private void CustomValidationRules()
        {

        }



        public void ValidationRules()
        {
            RuleFor(x => x.UserId).NotNull().WithMessage("UserId must not be null").NotEmpty().WithMessage("UserId must has value");

            RuleFor(x => x.CourseId).NotNull().WithMessage("CourseId must not be null").NotEmpty().WithMessage("CourseId must has value");
        }
    }
}
