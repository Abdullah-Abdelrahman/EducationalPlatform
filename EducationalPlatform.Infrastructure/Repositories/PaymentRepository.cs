using EducationalPlatform.Data.Entities;
using EducationalPlatform.Infrastructure.Abstracts;
using EducationalPlatform.Infrastructure.Bases;
using EducationalPlatform.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EducationalPlatform.Infrastructure.Repositories
{
    public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
    {
        private readonly DbSet<Payment> _payments;

        public PaymentRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
            _payments = dbContext.Set<Payment>();

        }
    }
}
