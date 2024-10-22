using AutoMapper;

namespace EducationalPlatform.Core.Mapping.Payment
{
    public partial class PaymentProfile : Profile
    {

        public PaymentProfile()
        {
            AddPaymentMapping();
        }
    }
}
