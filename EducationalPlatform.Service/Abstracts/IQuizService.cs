using EducationalPlatform.Data.Dto;
using EducationalPlatform.Data.Entities;

namespace EducationalPlatform.Service.Abstracts
{
    public interface IQuizService
    {
        public Task<string> AddQuiz(Quiz quiz, List<QuizQuestionDto>? quizQuestions);

        public Task<string> DeleteQuizById(int id);

        public Task<List<Quiz>> GetQuizListAsync();

        public Task<Quiz> GetQuizByIdAsync(int id);


        public Task<string> UpdateQuizAsync(Quiz Quiz);


        public Task<OpenQuizDto> OpenQuizSubmitAsync(int QuizId, string UserId);

        public Task<string> CloseQuizSubmitAsync(int SubmitId, List<QuizQuestionAnswerDto> quizQuestionAnswerDtos);


    }
}
