using EducationalPlatform.Core.Features.Question.Commands.Models;
using FluentValidation;

namespace EducationalPlatform.Core.Features.Question.Commands.Validations
{
    public class AddQuestionValidator : AbstractValidator<AddQuestionCommand>
    {
        #region
        public AddQuestionValidator()
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
            RuleFor(x => x.QuestionText).NotNull().WithMessage("QuestionText must not be null").NotEmpty().WithMessage("QuestionText must has value");

            RuleFor(x => x.QuestionType).NotNull().WithMessage("QuestionType must not be null").NotEmpty().WithMessage("QuestionType must has value");



        }
    }
}
