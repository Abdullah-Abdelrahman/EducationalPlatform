using EducationalPlatform.Core.Features.Answer.Commands.Models;
using FluentValidation;

namespace EducationalPlatform.Core.Features.Answer.Commands.Validators
{
    public class EditAnswerValidator : AbstractValidator<EditAnswerCommand>
    {

        public EditAnswerValidator()
        {
            ValidationRules();
        }


        public void ValidationRules()
        {

            RuleFor(x => x.AnswerId).NotNull().WithMessage("Id must not be null").NotEmpty().WithMessage("Id must has value");


            RuleFor(x => x.AnswerText).NotNull().WithMessage("AnswerText must not be null").NotEmpty().WithMessage("AnswerText must has value");

        }
    }
}
