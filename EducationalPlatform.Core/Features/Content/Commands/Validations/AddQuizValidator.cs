using EducationalPlatform.Core.Features.Content.Commands.Models;
using FluentValidation;

namespace EducationalPlatform.Core.Features.Content.Commands.Validations
{
    public class AddQuizValidator : AbstractValidator<AddQuizCommand>
    {

        #region
        public AddQuizValidator()
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


            RuleFor(x => x.Title).NotNull().WithMessage("Title must not be null").NotEmpty().WithMessage("Title must has value");

            RuleFor(x => x.Description).NotNull().WithMessage("Description must not be null");


        }
    }
}
