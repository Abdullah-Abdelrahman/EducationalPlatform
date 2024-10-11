using EducationalPlatform.Core.Features.Question.Commands.Models;
using FluentValidation;

namespace EducationalPlatform.Core.Features.Question.Commands.Validations
{
    public class EditQuestionValidator : AbstractValidator<EditQuestionCommand>
    {
        #region
        public EditQuestionValidator()
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

            RuleFor(x => x.correctAnswerId).NotNull().WithMessage("correctAnswerId must not be null").NotEmpty().WithMessage("correctAnswerId must has value");


        }
    }
}
