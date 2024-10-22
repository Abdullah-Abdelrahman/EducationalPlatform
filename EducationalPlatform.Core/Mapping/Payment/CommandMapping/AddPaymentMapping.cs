using EducationalPlatform.Core.Features.Payment.Commands.Models;

using Pay = EducationalPlatform.Data.Entities;
namespace EducationalPlatform.Core.Mapping.Payment
{
    public partial class PaymentProfile
    {
        public void AddPaymentMapping()
        {
            CreateMap<AddPaymentCommand, Pay.Payment>().ForMember(destnation => destnation.UserId, opt => opt.MapFrom(src => src.UserId)).ForMember(destnation => destnation.Amount, opt => opt.MapFrom(src => src.Amount));
        }
    }
}
