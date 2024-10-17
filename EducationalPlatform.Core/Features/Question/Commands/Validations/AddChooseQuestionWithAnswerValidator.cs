using EducationalPlatform.Core.Features.Question.Commands.Models;
using FluentValidation;

namespace EducationalPlatform.Core.Features.Question.Commands.Validations
{
    public class AddChooseQuestionWithAnswerValidator : AbstractValidator<AddQuestionWithAnswerCommand>
    {


        #region
        public AddChooseQuestionWithAnswerValidator()
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
            RuleFor(x => x.CorrectAnswer).NotNull().WithMessage("CorrectAnswer must not be null").NotEmpty().WithMessage("CorrectAnswer must has value");
            RuleFor(x => x.ChoiceList).NotNull().WithMessage("ChoiceList must not be null").NotEmpty().WithMessage("ChoiceList must has value");



        }
    }
}
