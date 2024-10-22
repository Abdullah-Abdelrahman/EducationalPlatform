using EducationalPlatform.Data.Entities;
using EducationalPlatform.Infrastructure.Abstracts;
using EducationalPlatform.Service.Abstracts;
using Microsoft.AspNetCore.Identity;

namespace EducationalPlatform.Service.Implementations
{
    public class EnrollmentService : IEnrollmentService
    {

        private readonly IEnrollmentRepository _enrollmentRepository;

        private readonly ICourseService _courseService;

        private readonly UserManager<AppUser> _userManager;
        public EnrollmentService(IEnrollmentRepository enrollmentRepository, ICourseService courseService, UserManager<AppUser> userManager)
        {
            _enrollmentRepository = enrollmentRepository;
            _courseService = courseService;
            _userManager = userManager;
        }
        public async Task<string> AddEnrollment(Enrollment enrollment)
        {
            var transact = _enrollmentRepository.BeginTransaction();
            try
            {
                enrollment.FinalPrice = (await _courseService.GetCourseByIdAsync(enrollment.CourseId)).Price;
                var user = await _userManager.FindByIdAsync(enrollment.UserId);

                if (user == null)
                {
                    return $"there is no user with id ={enrollment.UserId}";
                }
                else
                {
                    if (user.Balance >= enrollment.FinalPrice)
                    {
                        user.Balance -= enrollment.FinalPrice;
                        await _userManager.UpdateAsync(user);
                    }
                }


                var newEnrollment = await _enrollmentRepository.AddAsync(enrollment);


                await transact.CommitAsync();

                if (newEnrollment != null)
                {
                    return "Success";

                }

                return "Failed";
            }
            catch
            {
                await transact.RollbackAsync();
                return "Falied";
            }


        }

        public Task<Enrollment> GetEnrollmentByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Enrollment>> GetEnrollmentListAsync()
        {
            throw new NotImplementedException();
        }
    }
}
