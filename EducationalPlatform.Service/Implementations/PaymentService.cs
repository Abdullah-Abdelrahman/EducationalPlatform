using EducationalPlatform.Data.Entities;
using EducationalPlatform.Infrastructure.Abstracts;
using EducationalPlatform.Service.Abstracts;
using Microsoft.AspNetCore.Identity;

namespace EducationalPlatform.Service.Implementations
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;

        private readonly UserManager<AppUser> _userManager;
        public PaymentService(IPaymentRepository paymentRepository, UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _paymentRepository = paymentRepository;
        }
        public async Task<string> AddPayment(Payment payment)
        {
            var transact = _paymentRepository.BeginTransaction();

            try
            {
                payment.PaymentDate = DateTime.Now;

                await _paymentRepository.AddAsync(payment);

                var user = await _userManager.FindByIdAsync(payment.UserId);

                user.Balance += payment.Amount;

                await transact.CommitAsync();
                return "Success";

            }
            catch
            {
                await transact.RollbackAsync();
                return "Falied";
            }
        }

        public Task<Payment> GetPaymentByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Payment>> GetPaymentsListAsync()
        {
            throw new NotImplementedException();
        }
    }
}
