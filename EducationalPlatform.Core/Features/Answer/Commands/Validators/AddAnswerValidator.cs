using EducationalPlatform.Core.Features.Answer.Commands.Models;
using FluentValidation;

namespace EducationalPlatform.Core.Features.Answer.Commands.Validators
{
    public class AddAnswerValidator : AbstractValidator<AddAnswerCommand>
    {

        public AddAnswerValidator()
        {
            ValidationRules();
            CustomValidationRules();
        }
        public void ValidationRules()
        {
            RuleFor(x => x.AnswerText).NotNull().WithMessage("AnswerText must not be null").NotEmpty().WithMessage("AnswerText must has value");


        }
        private void CustomValidationRules()
        {

        }




    }
}
