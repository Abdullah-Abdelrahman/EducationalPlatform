using EducationalPlatform.Data.Entities;

namespace EducationalPlatform.Service.Abstracts
{
    public interface IPaymentService
    {
        public Task<List<Payment>> GetPaymentsListAsync();

        public Task<Payment> GetPaymentByIdAsync(int id);

        public Task<string> AddPayment(Payment payment);
    }
}
