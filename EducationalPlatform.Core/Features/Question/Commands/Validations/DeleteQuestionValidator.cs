using EducationalPlatform.Core.Features.Question.Commands.Models;
using FluentValidation;

namespace EducationalPlatform.Core.Features.Question.Commands.Validations
{
    public class DeleteQuestionValidator : AbstractValidator<DeleteQuestionCommand>
    {

        #region
        public DeleteQuestionValidator()
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
            RuleFor(x => x.Id).NotNull().WithMessage("Id must not be null").NotEmpty().WithMessage("Id must has value");
        }
    }
}
