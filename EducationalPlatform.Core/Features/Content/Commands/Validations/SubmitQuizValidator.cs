using EducationalPlatform.Core.Features.Content.Commands.Models;
using FluentValidation;

namespace EducationalPlatform.Core.Features.Content.Commands.Validations
{
    public class SubmitQuizValidator : AbstractValidator<SubmitQuizCommand>
    {
        #region
        public SubmitQuizValidator()
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


            RuleFor(x => x.QuizId).NotNull().WithMessage("QuizId must not be null").NotEmpty().WithMessage("QuizId must has value");

            RuleFor(x => x.UserId).NotNull().WithMessage("UserId must not be null").NotEmpty().WithMessage("UserId must has value");


            RuleFor(x => x.SubmitId).NotNull().WithMessage("SubmitId must not be null").NotEmpty().WithMessage("SubmitId must has value");

        }
    }
}
