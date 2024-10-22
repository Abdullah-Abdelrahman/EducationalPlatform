using EducationalPlatform.Data.Dto;
using EducationalPlatform.Data.Entities;
using EducationalPlatform.Infrastructure.Abstracts;
using EducationalPlatform.Service.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace EducationalPlatform.Service.Implementations
{
    public class QuizService : IQuizService
    {
        private readonly IQuizRepository _quizRepository;

        private readonly IQuizQuestionRepository _quizQuestionRepository;

        private readonly IQuestionService _questionService;

        private readonly ISubmitRepository _submitRepository;


        private readonly IQuizQuestionAnswerRepository _quizQuestionAnswerRepository;

        public QuizService(IQuizRepository quizRepository, IQuizQuestionRepository quizQuestionRepository, IQuestionService questionService, ISubmitRepository submitRepository, IQuizQuestionAnswerRepository quizQuestionAnswerRepository)
        {
            _quizQuestionRepository = quizQuestionRepository;
            _quizRepository = quizRepository;
            _questionService = questionService;
            _submitRepository = submitRepository;
            _quizQuestionAnswerRepository = quizQuestionAnswerRepository;
        }
        public async Task<string> AddQuiz(Quiz quiz, List<QuizQuestionDto>? quizQuestions)
        {

            quiz.ContentType = "Quiz";

            var newQuiz = await _quizRepository.AddAsync(quiz);



            foreach (var question in quizQuestions)
            {
                if ((await _questionService.ExistByIdAsync(question.QuestionId)))
                {
                    await _quizQuestionRepository.AddAsync(new QuizQuestion()
                    {
                        QuizId = newQuiz.ContentId,
                        QuestionId = question.QuestionId,
                        Points = question.Points,

                    });
                }

            }



            return "Success";
        }

        public async Task<string> CloseQuizSubmitAsync(int SubmitId, List<QuizQuestionAnswerDto> quizQuestionAnswerDtos)
        {
            try
            {
                var submit = await _submitRepository.GetByIdAsync(SubmitId);

                int partialresult = 0;

                foreach (var item in quizQuestionAnswerDtos)
                {
                    var question = await _questionService.GetQuestionByIdAsync(item.QuestionId);
                    if (question != null)
                    {
                        if (question.correctAnswerId == item.AnswerId)
                        {
                            partialresult++;
                        }

                        var record = new QuizQuestionAnswer()
                        {
                            SubmitId = SubmitId,
                            QuestionId = item.QuestionId,
                            AnswerId = item.AnswerId
                        };
                        await _quizQuestionAnswerRepository.AddAsync(record);
                    }
                }
                submit.Partialresult = partialresult;
                submit.EndDate = DateTime.Now;


                await _submitRepository.UpdateAsync(submit);
                return "Success";
            }
            catch (Exception ex)
            {
                return "Fail";

            }



        }

        public Task<string> DeleteQuizById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Quiz> GetQuizByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Quiz>> GetQuizListAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<OpenQuizDto> OpenQuizSubmitAsync(int QuizId, string UserId)
        {
            var newSubmit = new Submit()
            {
                QuizId = QuizId,
                UserId = UserId,
                StartDate = DateTime.Now
            };

            await _submitRepository.AddAsync(newSubmit);



            var openQuizDto = new OpenQuizDto()
            {
                SubmitId = newSubmit.SubmitId,
                UserId = UserId,
                QuizId = newSubmit.QuizId,
                StartDate = newSubmit.StartDate,
                EndDate = newSubmit.StartDate.AddMinutes((await _quizRepository.GetByIdAsync(QuizId)).TimeInMinute)
            };

            var quesionList = new List<QuizSubmitQuestionDto>();

            var quizQuestions = _quizQuestionRepository.GetTableNoTracking().Where(q => q.QuizId == QuizId).Include(q => q.Question).ToList();

            foreach (var item in quizQuestions)
            {
                var QSQDto = new QuizSubmitQuestionDto()
                {
                    QuestionId = item.QuestionId,
                    QuestionText = item.Question.QuestionText,
                    QuestionImage = item.Question.QuestionImage

                };

                if (item.Question.QuestionType == "Choose")
                {
                    QSQDto.ChoiceList = (await _questionService.GetQuestionByIdAsync(item.Question.QuestionId)).ChoiceList;
                }
                else if (item.Question.QuestionType == "TrueOrFalse")
                {
                    QSQDto.ChoiceList = (await _questionService.GetQuestionByIdAsync(item.Question.QuestionId)).ChoiceList;
                }

                quesionList.Add(QSQDto);
            }

            openQuizDto.Questions = quesionList;

            return openQuizDto;


        }

        public Task<string> UpdateQuizAsync(Quiz Quiz)
        {
            throw new NotImplementedException();
        }
    }
}
