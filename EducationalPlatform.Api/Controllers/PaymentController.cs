using EducationalPlatform.Api.Base;
using EducationalPlatform.Core.Features.Payment.Commands.Models;
using EducationalPlatform.Data.MetaData;
using Microsoft.AspNetCore.Mvc;

namespace EducationalPlatform.Api.Controllers
{

    [ApiController]
    public class PaymentController : AppControllerBase
    {
        [HttpPost(Router.PaymentRouter.Create)]
        public async Task<IActionResult> CreatePayment([FromBody] AddPaymentCommand command)
        {
            var response = await Mediator.Send(command);

            return NewResult(response);
        }

    }
}
