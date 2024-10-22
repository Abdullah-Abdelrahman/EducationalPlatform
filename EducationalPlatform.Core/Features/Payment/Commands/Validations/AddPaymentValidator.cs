using EducationalPlatform.Core.Features.Payment.Commands.Models;
using FluentValidation;

namespace EducationalPlatform.Core.Features.Payment.Commands.Validations
{
    public class AddPaymentValidator : AbstractValidator<AddPaymentCommand>
    {

        #region
        public AddPaymentValidator()
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

            RuleFor(x => x.Amount).NotNull().WithMessage("Amount must not be null").NotEmpty().WithMessage("Amount must has value");

            RuleFor(x => x.Method).NotNull().WithMessage("Method must not be null").NotEmpty().WithMessage("Method must has value");
        }
    }
}
