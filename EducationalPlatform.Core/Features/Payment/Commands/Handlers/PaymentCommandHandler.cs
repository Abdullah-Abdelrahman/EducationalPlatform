using AutoMapper;
using EducationalPlatform.Core.Bases;
using EducationalPlatform.Core.Features.Payment.Commands.Models;
using EducationalPlatform.Service.Abstracts;
using MediatR;
using Pay = EducationalPlatform.Data.Entities;

namespace EducationalPlatform.Core.Features.Payment.Commands.Handlers
{
    public class PaymentCommandHandler : ResponseHandler,
        IRequestHandler<AddPaymentCommand, Response<string>>
    {
        private readonly IPaymentService _paymentService;
        private readonly IMapper _mapper;
        public PaymentCommandHandler(IMapper mapper, IPaymentService paymentService)
        {
            _paymentService = paymentService;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(AddPaymentCommand request, CancellationToken cancellationToken)
        {
            var payment = _mapper.Map<Pay.Payment>(request);
            var result = await _paymentService.AddPayment(payment);

            if (result == "Success")
            {
                return Success<string>("Add to Balance Successfuly");
            }
            else
            {
                return BadRequest<string>(result);
            }
        }
    }
}
