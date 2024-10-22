namespace EducationalPlatform.Service.Abstracts
{
    public interface IEmailService
    {
        public Task<string> SendEmailAsync(string email, string Message);

    }
}
