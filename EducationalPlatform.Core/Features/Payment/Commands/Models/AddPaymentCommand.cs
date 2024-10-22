using EducationalPlatform.Core.Bases;
using MediatR;

namespace EducationalPlatform.Core.Features.Payment.Commands.Models
{
    public class AddPaymentCommand : IRequest<Response<string>>
    {

        public decimal Amount { get; set; }

        public string Method { get; set; }

        public string UserId { get; set; }

    }
}
