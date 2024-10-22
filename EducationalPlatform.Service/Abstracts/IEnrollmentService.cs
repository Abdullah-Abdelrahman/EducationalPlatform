using EducationalPlatform.Data.Entities;

namespace EducationalPlatform.Service.Abstracts
{
    public interface IEnrollmentService
    {

        public Task<List<Enrollment>> GetEnrollmentListAsync();

        public Task<Enrollment> GetEnrollmentByIdAsync(int id);

        public Task<string> AddEnrollment(Enrollment enrollment);
    }
}
