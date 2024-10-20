using EducationalPlatform.Service.Abstracts;
using EducationalPlatform.Service.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace EducationalPlatform.Service
{
    public static class ServiceDependencies
    {

        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {

            services.AddTransient<ICourseService, CourseService>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IAuthorizationService, AuthorizationService>();

            services.AddTransient<IAnswerService, AnswerService>();
            services.AddTransient<IQuestionService, QuestionService>();
            services.AddTransient<IContentService, ContentService>();
            services.AddTransient<IQuizService, QuizService>();

            services.AddTransient<IFileUploadService, FileUploadService>();





            return services;
        }
    }
}
