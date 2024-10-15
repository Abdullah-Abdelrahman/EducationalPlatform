using EducationalPlatform.Data.Dto;
using EducationalPlatform.Data.Entities;
using EducationalPlatform.Infrastructure.Abstracts;
using EducationalPlatform.Service.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace EducationalPlatform.Service.Implementations
{
    public class QuestionService : IQuestionService
    {

        private readonly IQuestionRepository _questionRepository;

        private readonly IAnswerRepository _answerRepository;
        public QuestionService(IQuestionRepository questionRepository,
            IAnswerRepository answerRepository)
        {
            _questionRepository = questionRepository;
            _answerRepository = answerRepository;
        }
        public async Task<string> AddQuestion(AddQuestionRequest request)
        {
            if (request.QuestionType == "Writen")
            {

                if (request.correctAnswerId == null)
                {
                    return "CorrectAnswerId must not be null";
                }


                var writenQuestion = new WriteQuestion()
                {
                    QuestionText = request.QuestionText,
                    QuestionImage = request.QuestionImage,
                    CorrectAnswerId = (int)request.correctAnswerId,
                    QuestionType = request.QuestionType

                };

                var result = await _questionRepository.AddWritenQuestionAsync(writenQuestion);

                if (result == "Success")
                {
                    return "Success";
                }
                else if (result == "Cant Add")
                {
                    return "Cant Add";
                }
                else
                {
                    return "somthing bad Happened";
                }
            }
            else if (request.QuestionType == "TrueOrFalse")
            {
                if (request.correctAnswerId == null)
                {
                    return "CorrectAnswer must not be null";
                }

                var trueOrFalseQuestion = new TrueOrFalseQuestion()
                {
                    QuestionText = request.QuestionText,
                    QuestionImage = request.QuestionImage,
                    CorrectAnswerId = (int)request.correctAnswerId,
                    QuestionType = request.QuestionType,

                };

                var result = await _questionRepository.AddTrueOrFalseQuestionAsync(trueOrFalseQuestion);

                if (result == "Success")
                {
                    return "Success";
                }
                else if (result == "Cant Add")
                {
                    return "Cant Add";
                }
                else
                {
                    return "somthing bad Happened";
                }
            }
            else if (request.QuestionType == "Choose")
            {
                if (request.correctAnswerId == null)
                {
                    return "CorrectAnswer must not be null";
                }
                if (request.answerListIds == null)
                {
                    return "answerListIds must not be null";
                }

                var answerList = new List<Answer>();

                foreach (var id in request.answerListIds)
                {
                    answerList.Add(await _answerRepository.GetByIdAsync(id));
                }

                var chooseQuestion = new ChooseQuestion()
                {
                    QuestionText = request.QuestionText,
                    QuestionImage = request.QuestionImage,
                    CorrectAnswerId = (int)request.correctAnswerId,
                    QuestionType = request.QuestionType,
                    ChoiceList = answerList

                };

                var result = await _questionRepository.AddChooseQuestionAsync(chooseQuestion);

                if (result == "Success")
                {
                    return "Success";
                }
                else if (result == "Cant Add")
                {
                    return "Cant Add";
                }
                else
                {
                    return "somthing bad Happened";
                }

            }
            else
            {
                return $"No Question with type = {request.QuestionType}";
            }
        }

        public async Task<string> DeleteQuestionById(int id)
        {
            var question = await _questionRepository.GetByIdAsync(id);

            if (question == null)
            {
                return "NotFound";
            }
            else
            {
                try
                {
                    await _questionRepository.DeleteAsync(question);

                    return "Success";
                }
                catch (Exception ex)
                {
                    return "An error wcure while tring to delete the entity";
                }



            }
        }

        public async Task<GetQuestionResult> GetQuestionByIdAsync(int id)
        {
            var response = new GetQuestionResult();
            var question = await _questionRepository.GetByIdAsync(id);

            if (question != null)
            {
                response.QuestionText = question.QuestionText;
                response.QuestionType = question.QuestionType;
                response.QuestionImage = question.QuestionImage;
                response.correctAnswerId = question.CorrectAnswerId;
                response.ChoiceList = await _questionRepository.GetChoiceListAsyncFor(question.QuestionType, question.QuestionId);
            }


            return response;
        }

        public async Task<List<Question>> GetQuestionListAsync()
        {
            var list = await _questionRepository.GetTableNoTracking()
                .ToListAsync();

            return list;
        }

        public async Task<List<Question>> GetQuestionWithAnswerListAsync()
        {
            var Questionlist = await _questionRepository.GetTableNoTracking().Include(x => x.Answer)
                 .ToListAsync();
            return Questionlist;
        }

        public async Task<string> UpdateQuestionAsync(EditQuestionResult request)
        {

            var transact = _questionRepository.BeginTransaction();
            try
            {
                var result = await _questionRepository.UpdateByTypeAsync(request);

                await transact.CommitAsync();
                return result;

            }
            catch
            {
                await transact.RollbackAsync();
                return "Falied";
            }

        }

    }
}
